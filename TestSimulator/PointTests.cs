namespace TestSimulator;

using Simulator;
public class PointTests
{
    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.Next(dir);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, -1)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.NextDiagonal(dir);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}