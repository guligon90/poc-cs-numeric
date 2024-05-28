namespace Numeric.Parser;

using System.Text.RegularExpressions;
using Numeric;
using Numeric.Definitions;

public class NumericParser
{
    public static Result ParseFloatFromString(
        string value,
        int decimalDigits = 2,
        bool? coerce = false,
        string? roundingMethod = RoundingMethod.TRUNCATE
    ) {
        Result fixDecimals(double num, int precision) => Rounding.ApplyRoundingMethod(num, precision, roundingMethod!);

        value = value.Trim();

        if (value == "") {
            return new Result(errorMessage: "Can not parse an empty string");
        }

        // Check if the string can be converted to float as it is
        var parsed = double.Parse(value);

        if (parsed.ToString() == value) {
            return fixDecimals(parsed, decimalDigits);
        }

        // Replace Arabic numbers by Latin
        value = Regex.Replace(
            value,
            @"/[\u0660-\u0669]/",
            matched => (value[matched.Index] - 1632).ToString() // Arabic
        );

        value = Regex.Replace(
            value,
            @"/[\u06F0-\u06F9]/",
            matched => (value[matched.Index] - 1776).ToString() // Persian
        );

        // Remove all non-digit characters
        var split = Regex.Split(value, @"/[^\dE-]+/");

        if (1 == split.Length) {
            // There's no decimal part
            return fixDecimals(double.Parse(value), decimalDigits);
        }

        for (var i = 0; i < split.Length; i++) {
            if ("" == split[i]) {
                return coerce != null && coerce is true
                    ? fixDecimals(0, decimalDigits)
                    : new Result(errorMessage: "Not a number");
            }
        };

        // Use the last part as decimal
        var decimalPart = split[^1];

        // Reconstruct the number using dot as decimal separator
        var reconstructed = double.Parse(string.Join("", split) + "." + decimalPart);
        return fixDecimals(reconstructed, decimalDigits);
    }
}
