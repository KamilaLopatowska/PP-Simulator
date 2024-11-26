namespace TestSimulator;

using Simulator;


public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)] 
    [InlineData(15, 1, 10, 10)] 
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Short", 5, 10, '-', "Short")]
    [InlineData("VeryLongString", 5, 10, '-', "VeryLongSt")] 
    [InlineData(" A ", 2, 5, '-', "A-")] 
    [InlineData(" ", 2, 5, '-', "--")]
    [InlineData("a                     b", 3, 10, '-', "A--")]

    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}
