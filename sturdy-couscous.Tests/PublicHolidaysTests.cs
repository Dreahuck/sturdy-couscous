using System;
using sturdy_cousous.Engine;

namespace sturdy_couscous.Tests
{
	public class PublicHolidaysTests
	{

		[Theory]
		[InlineData(2024,01,01, false)] //Jour de l'an 2024
        [InlineData(2024, 04, 01, false)] //Lundi de Pâque 2024
        [InlineData(2023, 04, 01, true)] //PAS le Lundi de Pâque
        [InlineData(2024, 05, 01, false)] //1er Mai 2024
        [InlineData(2024, 05, 08, false)] //8 Mai 2024
        [InlineData(2024, 05, 09, false)] //Ascension 2024
        [InlineData(2024, 05, 20, false)] //Pentecôte 2024
        [InlineData(2024, 07, 14, false)] //Fête nationale 2024
        [InlineData(2024, 08, 15, false)] //Assomption 2024
        [InlineData(2024, 11, 01, false)] //La Toussaint 2024
        [InlineData(2024, 11, 11, false)] //Armistice 2024
        [InlineData(2024, 12, 25, false)] //Noël 2024
        public void ShouldReturnFalseIfPublicHoliday(int year, int month, int day, bool result)
		{
			var date = new DateTime(year, month, day);
			Assert.Equal(result, PublicHolidays.IsNotPublicHolidays(date));
		}
	}
}

