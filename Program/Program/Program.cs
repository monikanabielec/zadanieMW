using System;

namespace Program
{
    class Program
    {
        static IUseInteface ui = new ConsoleUserInterface();
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    if (checkArgs(ref args))
                        ui.DisplayInfoMessage($"Result: {new DateRangeComputer(args[0], args[1]).GetRange()}");
                    else
                        ui.DisplayErrorMessage("Parameters are not a valid date type");
                }
                catch (Exception ex)
                {
                    ui.DisplayErrorMessage(ex.Message);
                }
                finally
                {
                    args = new string[0];
                    ui.DisplayInfoMessage("To try again press [N] on keyboard, to exit press other key");
                }

            } while (Console.ReadKey(true).Key == ConsoleKey.N);
        }

        private static bool checkArgs(ref string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    args = new string[] { ui.GetValueFromUser("Enter first date"), ui.GetValueFromUser("Enter second date") };
                    break;
                case 1:
                    args = new string[] { args[0], ui.GetValueFromUser("Enter second date") };
                    break;
                default:
                    break;
            }
            if (args.Length >= 2) // Ignore if greater than 2.
            {
                // If there are now errors in conversion return true.
                return (new DateConverter(args[0]).GetExceptions().Count == 0 &&
                    new DateConverter(args[1]).GetExceptions().Count == 0);
            }
            return false;
        }
    }
}
