using System.Globalization;
using Numeric;
using Numeric.Definitions;

class Program {
    public static void Main(string[] args) {
        Console.Clear();

        double number = -24723445.459012;
        int precision = 3;
        string groupSeparator = ",";
        string decimalSeparator = ".";
        string format = $"#{groupSeparator}##0{decimalSeparator}00000";

        // DemoInlineFormatting();
        DemoGenericFormatting(number, precision, format, groupSeparator, decimalSeparator);
    }

    private static void DemoInlineFormatting()
    {
        // Inline formatting
        Console.WriteLine("WITH FORMATTER");
        Console.WriteLine(string.Format(new Formatter(), "\t{0:custom}", 9));
        Console.WriteLine(string.Format(new Formatter(), "\t{0:custom}", 9.1));
    }

    private static Dictionary<string, Func<double, int, Result>> GenerateTestCases() {
        return new()
        {
            { RoundingMethod.UP, (double v, int p) => Rounding.ApplyRoundingMethod(v, p, RoundingMethod.UP) },
            { RoundingMethod.DOWN, (double v, int p) => Rounding.ApplyRoundingMethod(v, p, RoundingMethod.DOWN) },
            { RoundingMethod.NEAREST, (double v, int p) => Rounding.ApplyRoundingMethod(v, p, RoundingMethod.NEAREST) },
            { RoundingMethod.TRUNCATE, (double v, int p) => Rounding.ApplyRoundingMethod(v, p, RoundingMethod.TRUNCATE) },
        };
    }

    private static void DemoGenericFormatting(
        double number,
        int precision,
        string format,
        string groupSeparator,
        string decimalSeparator
    ) {
        List<List<string>> data = [];
        var testCases = GenerateTestCases();
        
        Formatter formatter = new Formatter();

        foreach(var item in testCases)
        {
            var roundingCallable = item.Value;
            var roundingResult = roundingCallable(number, precision);

            if (roundingResult.errorMessage != null) {
                Console.WriteLine(roundingResult.errorMessage);
                return;
            }

            double? rounded = roundingResult.value;

            if (rounded == null) {
                Console.WriteLine("Rounding method '" + item.Key + "' failed");
                return;
            }

            NumberFormatInfo? nfi = Formatter.BuildNumberFormatInfo(precision, groupSeparator, decimalSeparator);

            if (nfi == null) {
                Console.WriteLine("NumberFormatInfo construction failed. Check your separators!");
                return;
            }

            string formatted = formatter.Format(format: format, arg: rounded, formatProvider: nfi);
            data.Add([number.ToString(), item.Key.ToString(), format, groupSeparator, decimalSeparator, formatted]);
        }

        PrintFormatted(data);
    }

    private static void PrintFormatted(List<List<string>> data) {
        List<List<string>> table = [
            ["ORIGINAL VALUE", "ROUNDING METHOD", "FORMAT", "GROUP SEPARATOR", "DECIMAL SEPARATOR", "FINAL VALUE"],
        ];

        var tabbedData = Utilities.EvenColumns(20, table.Concat(data));

        Console.Write(tabbedData);
    }
}
