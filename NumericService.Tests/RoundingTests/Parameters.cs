namespace NumericService.Tests;

using System.Collections;

using Numeric;


public class BaseTestingParams
{
    protected const double DEFAULT_TOLERANCE = 1e-5;
}

public class ApplyRoundingMethodTestParams : BaseTestingParams, IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new BaseRoundingTestCase { Value = 1.1, Precision = 0, Method = RoundingMethod.UP, Expected = 2.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 1.23, Precision = 1, Method = RoundingMethod.UP, Expected = 1.3, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 1.543, Precision = 2, Method = RoundingMethod.UP, Expected = 1.55, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 22.45, Precision = -1, Method = RoundingMethod.UP, Expected = 30.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 1352, Precision = -2, Method = RoundingMethod.UP, Expected = 1400, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 1.5, Precision = 0, Method = RoundingMethod.DOWN, Expected = 1.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = -0.5, Precision = 0, Method = RoundingMethod.DOWN, Expected = -1.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 1.4188, Precision = 1, Method = RoundingMethod.NEAREST, Expected = 1.4, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new BaseRoundingTestCase { Value = 231.35678, Precision = 3, Method = RoundingMethod.TRUNCATE, Expected = 231.356, Tolerance = DEFAULT_TOLERANCE }, };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class RoundingUpTestParams : BaseTestingParams, IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new SpecificRoundingTestCase { Value = 1.1, Precision = 0, Expected = 2.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new SpecificRoundingTestCase { Value = 1.23, Precision = 1, Expected = 1.3, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new SpecificRoundingTestCase { Value = 1.543, Precision = 2, Expected = 1.55, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new SpecificRoundingTestCase { Value = 22.45, Precision = -1, Expected = 30.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new SpecificRoundingTestCase { Value = 1352, Precision = -2, Expected = 1400, Tolerance = DEFAULT_TOLERANCE }, };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class RoundingDownTestParams : BaseTestingParams, IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new SpecificRoundingTestCase { Value = 1.5, Precision = 0, Expected = 1.0, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new SpecificRoundingTestCase { Value = -0.5, Precision = 0, Expected = -1.0, Tolerance = DEFAULT_TOLERANCE }, };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class RoundingToNearestTestParams : BaseTestingParams, IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new SpecificRoundingTestCase { Value = 1.37, Precision = 1, Expected = 1.4, Tolerance = DEFAULT_TOLERANCE }, };
        yield return new object[] { new SpecificRoundingTestCase { Value = 1.4188, Precision = 1, Expected = 1.4, Tolerance = DEFAULT_TOLERANCE }, };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TruncateTestParams : BaseTestingParams, IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new SpecificRoundingTestCase { Value = 231.35678, Precision = 3, Expected = 231.356, Tolerance = DEFAULT_TOLERANCE }, };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}