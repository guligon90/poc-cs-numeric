namespace NumericService.Tests;

using Numeric;

using Xunit;

public class RoundingTest
{
    private static void DoAssert(Result? result, double expected, double? tolerance = null)
    {
        Assert.NotNull(result);
        Assert.Null(result.errorMessage);
        Assert.NotNull(result.value);

        if (tolerance != null)
        {
            Assert.True(
                Math.Abs(expected - (double)result.value) <= tolerance,
                $"Difference between expected and result above {tolerance}"
            );
        }
    }

    [Theory]
    [ClassData(typeof(ApplyRoundingMethodTestParams))]
    public void ApplyRoundingMethod_TestCaseValues_ReturnSuccessResult(
        BaseRoundingTestCase testCase
    )
    {
        var result = Rounding.ApplyRoundingMethod(testCase.Value, testCase.Precision, testCase.Method);
        DoAssert(result, testCase.Expected, testCase.Tolerance);
    }

    [Theory]
    [ClassData(typeof(RoundingUpTestParams))]
    public void RoundUp_TestCaseValues_ReturnSuccessResult(
        SpecificRoundingTestCase testCase
    )
    {
        var result = Rounding.RoundUp(testCase.Value, testCase.Precision);
        DoAssert(result, testCase.Expected, testCase.Tolerance);
    }

    [Theory]
    [ClassData(typeof(RoundingDownTestParams))]
    public void RoundDowm_TestCaseValues_ReturnSuccessResult(
        SpecificRoundingTestCase testCase
    )
    {
        var result = Rounding.RoundDown(testCase.Value, testCase.Precision);
        DoAssert(result, testCase.Expected, testCase.Tolerance);
    }

    [Theory]
    [ClassData(typeof(RoundingToNearestTestParams))]
    public void RoundToNearest_TestCaseValues_ReturnSuccessResult(
        SpecificRoundingTestCase testCase
    )
    {
        var result = Rounding.RoundToNearest(testCase.Value, testCase.Precision);
        DoAssert(result, testCase.Expected, testCase.Tolerance);
    }

    [Theory]
    [ClassData(typeof(TruncateTestParams))]
    public void RoundTruncate_TestCaseValues_ReturnSuccessResult(
        SpecificRoundingTestCase testCase
    )
    {
        var result = Rounding.Truncate(testCase.Value, testCase.Precision);
        DoAssert(result, testCase.Expected, testCase.Tolerance);
    }
}