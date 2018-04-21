using System;
using System.Collections.Generic;
using System.Globalization;

namespace Program
{
    internal class DateConverter
    {
        internal int Year
        {
            get
            {
                return dateTime.HasValue ? dateTime.Value.Year : DateTime.MinValue.Year;
            }
        }
        internal int Month
        {
            get
            {
                return dateTime.HasValue ? dateTime.Value.Month : 0;
            }
        }
        internal int Day
        {
            get
            {
                return dateTime.HasValue ? dateTime.Value.Day : 0;
            }
        }
        Dictionary<string, Exception> exceptions = new Dictionary<string, Exception>();
        int exceptionCounter = 0;
        DateTime? dateTime { get; set; }
        CultureInfo cultureInfo { get; set; }
        internal DateConverter(string _dateTimeStr)
        {
            try
            {
                cultureInfo = new CultureInfo("pl-PL");
                dateTime = Convert.ToDateTime(_dateTimeStr);
            }
            catch (Exception ex)
            {
                exceptionCounter++;
                exceptions.Add($"{exceptionCounter}: Error in internal DateConverter(string _dateTimeStr)", ex);
            }
        }
        /// <summary>
        /// If datetime is valid returns full nullable DateTime, else null
        /// </summary>
        /// <returns>DateTime?</returns>
        internal DateTime? GetFullDateTime()
        {
            return dateTime;
        }
        /// <summary>
        /// If date is valid returns string Month, else "00"
        /// </summary>
        /// <returns>string</returns>
        internal string GetMontchStr()
        {
            return Month != 0 ? Month.FixMonthOrDay() : "00";
        }
        /// <summary>
        /// If date is valid returns string Day, else "00"
        /// </summary>
        /// <returns>string</returns>
        internal string GetDayStr()
        {
            return Day != 0 ? Day.FixMonthOrDay() : "00";
        }
        /// <summary>
        /// Day and Month with culture included
        /// </summary>
        /// <returns>string</returns>
        internal string GetDayAndMonth()
        {
            try
            {
                string[] dateArray = GetFullDateStr().Split(currentCultureSeparator());
                string day = GetDayStr();
                string month = GetMontchStr();
                if (day == dateArray[0].FixMonthOrDay() && month == dateArray[1].FixMonthOrDay())
                    return $"{day}{currentCultureSeparator()}{month}";
                if (day == dateArray[1].FixMonthOrDay() && month == dateArray[0].FixMonthOrDay())
                    return $"{month}{currentCultureSeparator()}{day}";
                throw new ArgumentException($"Problem with date {GetFullDateStr()}");
            }
            catch (Exception ex)
            {
                exceptionCounter++;
                exceptions.Add($"{exceptionCounter}: Error in internal GetDayAndMonth()", ex);
                return null;
            }
        }
        /// <summary>
        /// Returns date with culture - if defined. Else return DateTime.MinValue
        /// </summary>
        /// <returns>string</returns>
        internal string GetFullDateStr()
        {
            return dateTime.HasValue ?
                dateTime.Value.ToString("d", cultureInfo) :
                DateTime.MinValue.ToString("d", cultureInfo);
        }
        /// <summary>
        /// Returns full exception dictionary for current object
        /// </summary>
        /// <returns>Dictionary<string, Exception></returns>
        /// 
        internal Dictionary<string, Exception> GetExceptions()
        {
            return exceptions;
        }
        /// <summary>
        /// Get separator for date
        /// </summary>
        /// <returns></returns>
        private char currentCultureSeparator()
        {
            return Convert.ToChar(cultureInfo.DateTimeFormat.DateSeparator);
        }
    }
}
