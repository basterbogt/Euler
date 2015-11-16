using System;

namespace Euler.Problems
{
    /// <summary>
    /// You are given the following information, but you may prefer to do some research for yourself.
    /// 
    ///      - 1 Jan 1900 was a Monday.
    ///      - Thirty days has September,
    ///        April, June and November.
    ///        All the rest have thirty-one,
    ///        Saving February alone,
    ///        Which has twenty-eight, rain or shine.
    ///        And on leap years, twenty-nine.
    ///      - A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    /// 
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    /// </summary>
    public class Problem019 : Problem
    {
        private enum days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private enum months { January, February, March, April, May, June, July, August, September, October, November, December }
        public override void Calculate()
        {
            int sundayCount = 0;//variable to keep track of all sundays that are on a 1st of a month, between the years [1901, 2000]
            int year = 1900; //We started counting at 1 january 1900, which is a monday;
            days currentDay = days.Monday; //thus, currentday is a monday

            while (year <= 2016) //Loop untill some year.. doesnt matter, as long as [1901,2000] is in this interval!
            {
                bool leapYear = IsLeapYear(year);
                foreach (months m in Enum.GetValues(typeof(months))) //Loop through all months
                {
                    int d = GetMonthDays(m, leapYear);//Get the amount of days of this month
                    for(int i = 1; i <= d; i++) //Loop through all the days of the month
                    {
                        if (currentDay == days.Sunday && i == 1 && year >= 1901 && year <= 2000) sundayCount++; //Check if its a sunday, on a 1st, between the years [1901,2000]
                        currentDay = NextDay(currentDay); //Next day pls!
                    }
                }
                year++;//Next year pls!
            }
            Print(sundayCount);//Print result!
        }
        

        private days NextDay(days d)
        {
            switch (d)
            {
                case days.Monday: return days.Tuesday;
                case days.Tuesday: return days.Wednesday;
                case days.Wednesday: return days.Thursday;
                case days.Thursday: return days.Friday;
                case days.Friday: return days.Saturday;
                case days.Saturday: return days.Sunday;
                default: return days.Monday;
            }
        }

        private bool IsLeapYear(int year)
        {
            if (year % 400 == 0) return true;
            if (year % 100 == 0) return false;
            return ((year-1900)%4 == 0);
        }

        private int GetMonthDays(months m, bool leapyear)
        {
            switch(m){
                case months.February:
                    {
                        if (leapyear) return 29;
                        return 28;
                    }
                case months.April:
                case months.June:
                case months.September:
                case months.November: return 30;
                default: return 31;
            }
        }



    }
}
