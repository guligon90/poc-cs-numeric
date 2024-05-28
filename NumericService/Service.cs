namespace Numeric;

public class Service
{
    public static bool IsNumeric(string value)
    {
        double parsed = double.Parse(value);

        return !double.IsNaN(parsed) && double.IsFinite(parsed);
    }

    public static bool IsNumeric(double value)
    {
        return !double.IsNaN(value) && double.IsFinite(value);
    }

    public static bool IsNumeric(int value)
    {
        return !double.IsNaN(value) && double.IsFinite(value);
    }

    public static bool IsInteger(string value)
    {
        double number = double.Parse(value);

        return double.IsInteger(number);
    }

    public static bool IsInteger(double value)
    {
        return double.IsInteger(value);
    }
}