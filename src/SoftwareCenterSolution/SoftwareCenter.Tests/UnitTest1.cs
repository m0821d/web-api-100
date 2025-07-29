namespace SoftwareCenter.Tests;

public class UnitTest1
{
    [Fact]
    public void DotNetCanAddTwoIntegers()
    {
        //Given
        int a = 10, b = 20, answer;
        //When
        answer = a + b;

        Assert.Equal(30, answer);
    }
    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 2, 12)]
    public void AddingSomeIntegers(int a, int b, int expected)
    {
        var answer = a + b;
        Assert.Equal(expected, answer);
    }
    
}
