using System;

namespace Program
{
    internal static class Extensions
    {
        internal static string FixMonthOrDay(this int value)
        {
            if (value < 0)
                throw new ArgumentException();
            return value < 10 ? $"0{value}" : value.ToString();
        }
        internal static string FixMonthOrDay(this string value)
        {
            return value.Length == 1 ? $"0{value}" : value.ToString();
        }
    }
}
