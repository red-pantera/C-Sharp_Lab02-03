using System;

namespace Zhenchak03.Models
{
    class Person
    {

        internal string Name { get; private set; }
        internal string Surname { get; private set; }
        internal string Email { get; private set; }
        internal DateTime DateOfBirth { get; private set; }


        internal bool IsAdult => BirthDataUtils.CalculateAge(DateOfBirth) >= 18;

        internal bool IsBirthday => BirthDataUtils.IsBirthday(DateOfBirth);

        internal AstrologicalSign AstrologicalSign => GetAstrologicalSign(DateOfBirth);

        internal ZodiacSign ZodiacSign => GetZodiacSign(DateOfBirth);

        internal Person(string name, string surname, string email, DateTime dateOfBirth) : this(name, surname, email)
        {
            if (!BirthDataUtils.IsValidBirthDate(dateOfBirth))
            {
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth));
            }
            DateOfBirth = dateOfBirth;
        }

        internal Person(string name, string surname, string email) : this(name, surname)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (!EmailValidator.IsValidFormat(email))
            {
                throw new ArgumentException("Email is incorrect");
            }
            Email = email;
        }

        internal Person(string name, string surname, DateTime dateOfBirth) : this(name, surname)
        {
            DateOfBirth = dateOfBirth;
        }

        internal Person(string name, string surname)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        static AstrologicalSign GetAstrologicalSign(DateTime birthDate)
        {
            const int astrologicalYearStartMonth = 3;

            int monthOrdinalFromMarch = birthDate.DayOfYear / 31 - astrologicalYearStartMonth;

            if (monthOrdinalFromMarch < 0)
            {
                monthOrdinalFromMarch += 12;
            }
            return (AstrologicalSign)monthOrdinalFromMarch;
        }

        static ZodiacSign GetZodiacSign(DateTime birthDate)
        {
            // the first year when the cycle would start after 0th yearAD
            const int firstCycleStartAd = 4;
            int inCycleYear = (birthDate.Year - firstCycleStartAd) % 12;
            return (ZodiacSign)inCycleYear;
        }
    }
}

