namespace Numeric;

using System.Globalization;

class Formatter
{
    public static NumberFormatInfo? BuildNumberFormatInfo(
        int numDecimalDigits = 2,
        string? groupSeparator = Separator.DOT,
        string? decimalSeparator = Separator.COMMA
    )
    {
        string[] supportedSeparators = [Separator.DOT, Separator.COMMA];

        bool Check(string s) => supportedSeparators.Any(item => item == s);

        return !(Check(groupSeparator!) && Check(decimalSeparator!))
            ? null
            : new NumberFormatInfo()
        {
            NumberDecimalDigits = numDecimalDigits!,
            NumberGroupSeparator = groupSeparator!,
            NumberDecimalSeparator = decimalSeparator!,
        };
    }

    public static string Format(double? value, NumberFormatInfo? nfi)
    {
        return value!.Value.ToString("N", nfi);
    }
}
