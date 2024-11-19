namespace TestSimulator;

using Simulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldThrowException_WhenPointsAreCollinear()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 10));
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 10, 0));
    }

    [Fact]
    public void Contains_ShouldReturnTrue_ForPointsInsideRectangle()
    {
        var rect = new Rectangle(0, 0, 10, 10);
        Assert.True(rect.Contains(new Point(5, 5)));
        Assert.True(rect.Contains(new Point(0, 0))); 
        Assert.True(rect.Contains(new Point(10, 10))); 
    }

    [Fact]
    public void Contains_ShouldReturnFalse_ForPointsOutsideRectangle()
    {
        var rect = new Rectangle(0, 0, 10, 10);
        Assert.False(rect.Contains(new Point(-1, 5)));
        Assert.False(rect.Contains(new Point(11, 10)));
    }
}
