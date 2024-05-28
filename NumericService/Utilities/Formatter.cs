namespace Numeric;

using System.Globalization;

class Formatter : IFormatProvider, ICustomFormatter
{
    public string Format(string? format = null, object? arg = null, IFormatProvider? formatProvider = null)
    {
        switch (format!.ToUpper())
        {
            case "CUSTOM":
                if (arg is short || arg is int || arg is long)
                    return arg.ToString()!;
                if (arg is float || arg is double)
                    return string.Format("{0:0.00}", arg);
                break;
            // Handle other
            default:
                try
                {
                    return HandleOtherFormats(format, arg!, formatProvider)!;
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                }
        }

        return arg!.ToString()!; // only as a last resort
    }

    private static string? HandleOtherFormats(string format, object arg, IFormatProvider? formatProvider = null)
    {
        if (arg is IFormattable)
            return formatProvider != null
                ? ((IFormattable)arg).ToString(format, formatProvider)
                : ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
        if (arg != null)
            return arg.ToString();

        return string.Empty;
    }

    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(ICustomFormatter))
            return this;
        return null;
    }

    public static NumberFormatInfo? BuildNumberFormatInfo(
        int numDecimalDigits = 2,
        string? groupSeparator = Separator.DOT,
        string? decimalSeparator = Separator.COMMA
    )
    {
        string[] supportedSeparators = [Separator.DOT, Separator.COMMA];

        bool check(string s) => supportedSeparators.Any(item => item == s);

        if (!(check(groupSeparator!) && check(decimalSeparator!)))
        {
            return null;
        }

        return new NumberFormatInfo()
        {
            NumberDecimalDigits = numDecimalDigits!,
            NumberGroupSeparator = groupSeparator!,
            NumberDecimalSeparator = decimalSeparator!,
        };
    }
}