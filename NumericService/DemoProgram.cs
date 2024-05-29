using System.Globalization;
using Numeric;

class DemoProgram
{
    public static void Main(string[] args)
    {
        Console.Clear();

        int precision = 2;
        double number = -24723445.00012;
        string groupSeparator = Separator.DOT;
        string decimalSeparator = Separator.COMMA;

        DemoFormatting(number, precision, groupSeparator, decimalSeparator);
    }

    private static Dictionary<string, Func<double, int, Result>> GenerateTestCases()
    {
        return new()
        {
            { RoundingMethod.UP, Rounding.RoundUp },
            { RoundingMethod.DOWN, Rounding.RoundDown },
            { RoundingMethod.NEAREST, Rounding.RoundToNearest },
            { RoundingMethod.TRUNCATE, Rounding.Truncate },
        };
    }

    private static void DemoFormatting(
        double number,
        int precision,
        string groupSeparator,
        string decimalSeparator
    )
    {
        List<List<string>> data = [];
        var testCases = GenerateTestCases();

        foreach (var tc in testCases)
        {
            (double?, string?) formatted = PerformFormatting(tc, number, precision, groupSeparator, decimalSeparator);

            if (formatted.Item1 == null || formatted.Item2 == null) {
                Console.WriteLine("Formatting process failed.");
                return;
            }

            data.Add([
                number.ToString(), // "ORIGINAL VALUE"
                tc.Key.ToString(), // "ROUNDING METHOD"
                formatted.Item1.ToString(), // "ROUNDED VALUE"
                groupSeparator,
                decimalSeparator,
                formatted.Item2 // "FINAL VALUE"
            ]);
        }

        PrintFormatted(data);
    }

    private static (double?, string?) PerformFormatting(
        KeyValuePair<string, Func<double, int, Result>> testCase,
        double value,
        int precision,
        string groupSeparator,
        string decimalSeparator
    ) {
        var roundingCallable = testCase.Value;
        var roundingResult = roundingCallable(value, precision);

        if (roundingResult.errorMessage != null)
        {
            Console.WriteLine(roundingResult.errorMessage);
            return (null, null);
        }

        double? rounded = roundingResult.value;

        if (rounded == null)
        {
            Console.WriteLine("Rounding method '" + testCase.Key + "' failed");
            return (null, null);
        }

        NumberFormatInfo? nfi = Formatter.BuildNumberFormatInfo(precision, groupSeparator, decimalSeparator);

        if (nfi == null)
        {
            Console.WriteLine("NumberFormatInfo construction failed. Check your separators!");
            return (null, null);
        }

        return (rounded, Formatter.Format(rounded, nfi));
    }

    private static void PrintFormatted(List<List<string>> data)
    {
        List<List<string>> table = [
            ["ORIGINAL VALUE", "ROUNDING METHOD", "ROUNDED VALUE", "GROUP SEPARATOR", "DECIMAL SEPARATOR", "FINAL VALUE"],
        ];

        var tabbedData = TableFormatter.EvenColumns(20, table.Concat(data));

        Console.Write(tabbedData);
    }
}
