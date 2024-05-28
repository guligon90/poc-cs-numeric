namespace NumericService.Tests;

public class SpecificRoundingTestCase
{
    public double Value { get; set; }
    public int Precision { get; set; }
    public double Expected { get; set; }
    public double Tolerance { get; set; }

}

public class BaseRoundingTestCase : SpecificRoundingTestCase
{
    public required string Method { get; set; }
}