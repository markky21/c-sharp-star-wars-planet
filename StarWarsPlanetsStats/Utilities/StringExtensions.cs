namespace StarWarsPlanetsStats.Utilities;

public static class StringExtensions
{
    public static int? ParseToIntNullable(this string? value)
    {
        return int.TryParse(value, out int result) ? result : null;
    }
    public static long? ParseToLongNullable(this string? value)
    {
        return long.TryParse(value, out long result) ? result : null;
    }
}