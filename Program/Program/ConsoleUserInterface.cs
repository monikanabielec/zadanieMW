using System;

namespace Program
{
    internal class ConsoleUserInterface : IUseInteface
    {
        public void DisplayInfoMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public string GetValueFromUser()
        {
            return Console.ReadLine();
        }
        public string GetValueFromUser(string message)
        {
            DisplayInfoMessage(message);
            return Console.ReadLine();
        }
    }
}
