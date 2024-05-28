namespace NumericService.Tests;

using Numeric;

using Xunit;

public class ServiceTest
{
    #region Sample_TestCode
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void IsNumeric_IntegerValues_ReturnTrue(int value)
    {
        var result = Service.IsNumeric(value);

        Assert.True(result, $"{value} should not be non-numeric");
    }
    #endregion

    [Theory]
    [InlineData("32")]
    [InlineData("2e-5")]
    [InlineData("523.05")]
    [InlineData("-0.77")]
    public void IsNumeric_StringValues_ReturnTrue(string value)
    {
        var result = Service.IsNumeric(value);

        Assert.True(result, $"{value} should not be non-numeric");
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(3e+12)]
    [InlineData(523.05)]
    [InlineData(-0.77)]
    public void IsNumeric_DoubleValues_ReturnTrue(double value)
    {
        var result = Service.IsNumeric(value);

        Assert.True(result, $"{value} should not be non-numeric");
    }
}