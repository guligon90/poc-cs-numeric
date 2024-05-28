namespace Numeric;

public class RangeChecker
{
    public static bool IsInRange(
        double value,
        double lowerLimit,
        double upperLimit,
        bool? includeLower = null,
        bool? includeUpper = null
    )
    {
        bool lowerTest = includeLower != null && includeLower is true ? lowerLimit <= value : lowerLimit < value;
        bool upperTest = includeUpper != null && includeUpper is true ? upperLimit >= value : upperLimit > value;

        return lowerTest && upperTest;
    }

    readonly public Dictionary<string, Func<double, double, double>> BasicOperations = new()
    {
        { Operator.ADDITION, (x, y) => x + y},
        { Operator.SUBTRACTION, (x, y) => x - y },
        { Operator.DIVISION, (x, y) => x / y },
        { Operator.PRODUCT, (x, y) => x * y },
    };

    readonly public Dictionary<string, Func<double, double, bool>> Unlimited = new()
    {
        {Operator.LTE, (x, y) => x <= y},
        {Operator.LT, (x, y) => x < y},
        {Operator.GTE, (x, y) => x >= y},
        {Operator.GT, (x, y) => x > y},
    };

    readonly public Dictionary<string, Func<double, double, double, bool?, bool?, bool>> Limited = new()
    {
        { Operator.RANGE, IsInRange },
        { Operator.OPEN_RANGE, (value, lowerLimit, upperLimit, includeUpper, includeLower) => IsInRange(value, lowerLimit, upperLimit) },
        { Operator.INCLUDE_UPPER_RANGE, (value, lowerLimit, upperLimit, includeUpper, includeLower) => IsInRange(value, lowerLimit, upperLimit, false, true) },
        { Operator.INCLUDE_LOWER_RANGE, (value, lowerLimit, upperLimit, includeUpper, includeLower) => IsInRange(value, lowerLimit, upperLimit, true, false) },
    };
}