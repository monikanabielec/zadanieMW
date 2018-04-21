using System;

namespace Program
{
    internal class DateRangeComputer
    {
        DateConverter firstDate { get; set; }
        DateConverter secondDate { get; set; }
        internal DateRangeComputer(string firstDateStr, string secondDateStr)
        {
            firstDate = new DateConverter(firstDateStr);
            secondDate = new DateConverter(secondDateStr);
            if (firstDate.GetFullDateTime() >= secondDate.GetFullDateTime())
                throw new ArgumentException("Second date must be greater then First");
        }
        internal string GetRange()
        {
            return (firstDate.Year == secondDate.Year && firstDate.Month == secondDate.Month) ?
                $"{firstDate.GetDayStr()} - {secondDate.GetFullDateStr()}" :
            (firstDate.Year == secondDate.Year && firstDate.Month < secondDate.Month) ?
                $"{firstDate.GetDayAndMonth()} - {secondDate.GetFullDateStr()}" :
                $"{firstDate.GetFullDateStr()} - {secondDate.GetFullDateStr()}";
        }
    }
}
