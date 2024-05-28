namespace Numeric;

using Numeric.Definitions;

public class Rounding {
    public static Result ApplyRoundingMethod(double value, int precision = 2, string method = RoundingMethod.NEAREST){
        // const truncate = () => {
        //     const multiplier = Math.pow(10, precision);

        //     return (value * multiplier) / multiplier;
        // }

        Dictionary<string, Func<double, double>> methodSwitcher = new()
        {
            { RoundingMethod.UP, Math.Floor },
            { RoundingMethod.DOWN, Math.Ceiling },
            { RoundingMethod.NEAREST, Math.Round },
            { RoundingMethod.TRUNCATE, Math.Truncate },
        };

        Func<double, double>? methodCallable = methodSwitcher[method];

        if (methodCallable == null) {
            return new Result(errorMessage: $"Rounding method {method} not supported");
        }

        double multiplier = Math.Pow(10, precision);

        return new Result(value: methodCallable(value * multiplier) / multiplier);
    }

    public static Result RoundToNearest(double value, int precision = 2) {
        return ApplyRoundingMethod(value, precision, RoundingMethod.NEAREST);
    }

    public static Result RoundUp(double value, int precision = 2) {
        return ApplyRoundingMethod(value, precision, RoundingMethod.UP);
    }

    public static Result RoundDown(double value, int precision = 2) {
        return ApplyRoundingMethod(value, precision, RoundingMethod.DOWN);
    }

    public static Result Truncate(double value, int precision = 2) {
        return ApplyRoundingMethod(value, precision, RoundingMethod.TRUNCATE);
    }    
}
