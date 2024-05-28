namespace Numeric.Definitions;

public class Result(double? value = null, string? errorMessage = null)
{
    public double? value = value;
    public string? errorMessage = errorMessage;
}
