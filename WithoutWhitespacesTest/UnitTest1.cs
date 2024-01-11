namespace WithoutWhitespacesTest;

public class UnitTest1
{
    [Theory]
    //[InlineData(8, 1234567, 9, "1234567", 64)]
    //[InlineData(3, 123, 9, "123", 8)]
    [InlineData(4, 1234, 9, "1234", 19)]
    public void Test1(int n, int c, int k, string s, long expected)
    {
        var result = Problem.Count(n, c, k, s);
        Assert.Equal(expected, result);
    }
}