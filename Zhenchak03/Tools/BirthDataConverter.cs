using System;

namespace Zhenchak03
{
    static class BirthDataUtils
    {
        const int MaxAge = 135;
        internal static bool IsBirthday(DateTime birthDate)
        {
            if (IsValidBirthDate(birthDate) == false)
            {
                throw new ArgumentException("Not valid birthDate");
            }
            return DateTime.Today.DayOfYear == birthDate.DayOfYear;
        }

        internal static int CalculateAge(DateTime birthDate)
        {
            return DateTime.Today.Year - birthDate.Year;
        }

        internal static bool IsValidBirthDate(DateTime birthDate)
        {
            return IsValidAge(CalculateAge(birthDate));
        }

        static bool IsValidAge(int age)
        {
            return age >= 0 && age <= MaxAge;
        }
    }
}

