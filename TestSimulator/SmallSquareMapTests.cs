namespace TestSimulator;

using Simulator.Maps;
using Simulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ShouldThrowException_WhenSizeIsInvalid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(4));
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(21));
    }

    [Fact]
    public void Exist_ShouldReturnTrue_ForPointsInsideMap()
    {
        var map = new SmallSquareMap(10);
        Assert.True(map.Exist(new Point(0, 0)));
        Assert.True(map.Exist(new Point(9, 9)));
    }

    [Fact]
    public void Exist_ShouldReturnFalse_ForPointsOutsideMap()
    {
        var map = new SmallSquareMap(10);
        Assert.False(map.Exist(new Point(-1, 0)));
        Assert.False(map.Exist(new Point(10, 10)));
    }

    [Fact]
    public void Next_ShouldReturnSamePoint_WhenNextIsOutsideMap()
    {
        var map = new SmallSquareMap(10);
        var result = map.Next(new Point(0, 0), Direction.Left); 
        Assert.Equal(new Point(0, 0), result);
    }

    [Fact]
    public void NextDiagonal_ShouldReturnSamePoint_WhenNextDiagonalIsOutsideMap()
    {
        var map = new SmallSquareMap(10);
        var result = map.NextDiagonal(new Point(0, 0), Direction.Left);
        Assert.Equal(new Point(0, 0), result);
    }
}
