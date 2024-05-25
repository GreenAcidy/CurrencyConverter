using System.Globalization;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Mock;
using CurrencyConverter.Query;
using CurrencyConverter.Services;
using CurrencyConverter.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class Program
    {
        private const string DeveloperName = "Kiryl Zhurauliou";
        private const string HintMessage = "Enter your command";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private static ICurrencyService currencyService = new CurrencyService(new ExchangeRatesQuery(new MockData()));
        private static ICurrencyValidator currencyValidator = new DefaultValidator(new ExchangeRatesQuery(new MockData()));
        private static bool isRunning = true;

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("sum", Sum),
            new Tuple<string, Action<string>>("stat", Stat),
            new Tuple<string, Action<string>>("exit", Exit),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "stat", "show available exchange rates.", "The 'stat' command show available exchange rates." },
            new string[] { "sum", "receive user input and return converted by exchange rates sum of two values.", "The 'sum' command receive user input and return converted by exchange rates sum of two values." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
        };

        /// <summary>
        /// method connecting the user and the program.
        /// </summary>
        /// <param name="args">input parameter.</param>
        public static void Main(string[] args)
        {
            var services = CreateServices();

            var curensyService = services.GetRequiredService<ICurrencyService>();

            Console.WriteLine($"Currency calculator, developed by {Program.DeveloperName}");
            Console.WriteLine("Using default validation rules.");
            Console.WriteLine("Available commands:");

            foreach (var helpMessage in helpMessages)
            {
                Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
            }

            Console.WriteLine(Program.HintMessage);

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (isRunning);
        }

        private static ServiceProvider CreateServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICurrencyService, CurrencyService>()
                .AddScoped<IExchangeRatesQuery, ExchangeRatesQuery>()
                .AddSingleton<MockData>(new MockData())
                .BuildServiceProvider();
            return serviceProvider;
        }

        private static void Sum(string parametrs)
        {
            Console.Write("Date: ");
            var date = ReadInput(DateConverter, DateValidation);

            Console.Write("First currency: ");
            var firstCurr = ReadInput(StringConverter, StringValidation);

            Console.Write("First number: ");
            var firstNumber = ReadInput(FloatConverter, FloatValidation);

            Console.Write("Second currency: ");
            var secondCurr = ReadInput(StringConverter, StringValidation);

            Console.Write("Second number: ");
            var secondNumber = ReadInput(FloatConverter, FloatValidation);

            Console.Write("Result currency: ");
            var resultCurr = ReadInput(StringConverter, StringValidation);

            Console.WriteLine($"{firstNumber} {firstCurr} + {secondNumber} {secondCurr} = {currencyService.Sum(date, firstCurr, firstNumber, secondCurr, secondNumber, resultCurr)} {resultCurr}");
        }

        private static T ReadInput<T>(Func<string, Tuple<bool, string, T>> converter, Func<T, Tuple<bool, string>> validator)
        {
            do
            {
                T value;

                var input = Console.ReadLine();
                var conversionResult = converter(input);

                if (!conversionResult.Item1)
                {
                    Console.WriteLine($"Conversion failed: {conversionResult.Item2}. Please, correct your input.");
                    continue;
                }

                value = conversionResult.Item3;

                var validationResult = validator(value);
                if (!validationResult.Item1)
                {
                    Console.WriteLine($"Validation failed: {validationResult.Item2}. Please, correct your input.");
                    continue;
                }

                return value;
            }
            while (true);
        }

        private static Tuple<bool, string, DateTime> DateConverter(string input)
        {
            bool isConv = true;
            if (input is null)
            {
                isConv = false;
            }

            DateTime date;
            CultureInfo iOCultureFormat = new ("en-US");
            DateTime.TryParse(input, iOCultureFormat, DateTimeStyles.None, out date);
            return Tuple.Create(isConv, input, date);
        }

        private static Tuple<bool, string, string> StringConverter(string input)
        {
            bool isConv = true;
            if (input is null)
            {
                isConv = false;
            }

            return Tuple.Create(isConv, input, (string)Convert.ChangeType(input, typeof(string)));
        }

        private static Tuple<bool, string, float> FloatConverter(string input)
        {
            bool isConv = true;
            if (input is null)
            {
                isConv = false;
            }

            return Tuple.Create(isConv, input, (float)Convert.ChangeType(input, typeof(float)));
        }

        private static Tuple<bool, string> DateValidation(DateTime date)
        {
            bool flag = true;
            try
            {
                currencyValidator.ValidateCurrencyDate(date);
            }
            catch
            {
                flag = false;
            }

            return Tuple.Create(flag, date.ToString());
        }

        private static Tuple<bool, string> StringValidation(string name)
        {
            bool flag = true;
            try
            {
                currencyValidator.ValidateNameOfCurrency(name);
            }
            catch
            {
                flag = false;
            }

            return Tuple.Create(flag, name);
        }

        private static Tuple<bool, string> FloatValidation(float exchange)
        {
            bool flag = true;
            try
            {
                currencyValidator.ValidateValue(exchange);
            }
            catch
            {
                flag = false;
            }

            return Tuple.Create(flag, exchange.ToString());
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void Stat(string parameters)
        {
            Console.WriteLine("Available dates:");
            foreach (DateTime date in currencyService.GetDays())
            {
                Console.WriteLine(date.ToString("yyyy.MM.dd"));
            }

            Console.WriteLine("Available currencies:");

            foreach (string curr in currencyService.GetCurrencies())
            {
                Console.WriteLine(curr.ToUpper());
            }
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }
    }
}
