namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public Point Bounce(Point p, Direction d)
        {
            var next = Next(p, d);
            if (Exist(next)) return next;

            // Change direction to bounce back
            return d switch
            {
                Direction.Up => Next(p, Direction.Down),
                Direction.Down => Next(p, Direction.Up),
                Direction.Left => Next(p, Direction.Right),
                Direction.Right => Next(p, Direction.Left),
                _ => p
            };
        }

        public Point BounceDiagonal(Point p, Direction d)
        {
            var next = NextDiagonal(p, d);
            if (Exist(next)) return next;

            // Change diagonal direction
            return d switch
            {
                Direction.Up => NextDiagonal(p, Direction.Down),
                Direction.Left => NextDiagonal(p, Direction.Right),
                Direction.Right => NextDiagonal(p, Direction.Left),
                Direction.Down => NextDiagonal(p, Direction.Up),
                _ => p
            };
        }
    }
}
