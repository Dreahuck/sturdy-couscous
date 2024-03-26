using System;
namespace sturdy_cousous.Engine;

public static class PublicHolidays
{
    public static bool IsNotPublicHolidays(DateTime date)
    {
        var easterDay = EasterDay(date.Year);
        return !IsNewYear(date)
            && !IsEasterMonday(easterDay, date)
            && !IsLabourDay(date)
            && !IsArmisticeMay(date)
            && !IsAscension(easterDay, date)
            && !IsPentecote(easterDay, date)
            && !IsBastilleDay(date)
            && !IsAssemption(date)
            && !IsSaintsDay(date)
            && !IsArmisticeNovember(date)
            && !IsChristmasDay(date);
    }
    private static DateTime EasterDay(int year)
    {
        int a = year % 19;
        int b = year / 100;
        int c = year % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;
        int month = (h + l - 7 * m + 114) / 31;
        int day = ((h + l - 7 * m + 114) % 31) + 1;
        return new(year, month, day);
    }

    private static bool IsNewYear(DateTime date)
    {
        return date.Month == 1 && date.Day == 1;
    }
    private static bool IsEasterMonday(DateTime easterDay, DateTime date)
    {
        return date.Date == easterDay.AddDays(1).Date;
    }
    private static bool IsLabourDay(DateTime date)
    {
        return date.Month == 5 && date.Day == 1;
    }
    private static bool IsArmisticeMay(DateTime date)
    {
        return date.Month == 5 && date.Day == 8;
    }
    private static bool IsAscension(DateTime easterDay, DateTime date)
    {
        return date.Date == easterDay.AddDays(39).Date;
    }
    private static bool IsPentecote(DateTime easterDay, DateTime date)
    {
        return date.Date == easterDay.AddDays(50).Date;
    }
    private static bool IsBastilleDay(DateTime date)
    {
        return date.Month == 7 && date.Day == 14;
    }
    private static bool IsAssemption(DateTime date)
    {
        return date.Month == 8 && date.Day == 15;
    }
    private static bool IsSaintsDay(DateTime date)
    {
        return date.Month == 11 && date.Day == 1;
    }
    private static bool IsArmisticeNovember(DateTime date)
    {
        return date.Month == 11 && date.Day == 11;
    }
    private static bool IsChristmasDay(DateTime date)
    {
        return date.Month == 12 && date.Day == 25;
    }
}
