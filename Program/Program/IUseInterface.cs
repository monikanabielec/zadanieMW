namespace Program
{
    interface IUseInteface
    {
        string GetValueFromUser();
        string GetValueFromUser(string message);
        void DisplayInfoMessage(string message);
        void DisplayErrorMessage(string message);
    }
}
