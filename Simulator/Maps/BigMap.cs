using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private readonly Dictionary<Point, List<Creature>> _mapObjects;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException("Map size exceeds the limit of 1000x1000.");
            }
            _mapObjects = new Dictionary<Point, List<Creature>>();
        }

        public override void Add(Creature creature, Point position)
        {
            if (!Exist(position))
            {
                throw new ArgumentOutOfRangeException("Position out of bounds.");
            }

            if (!_mapObjects.ContainsKey(position))
            {
                _mapObjects[position] = new List<Creature>();
            }

            _mapObjects[position].Add(creature);
        }

        public override void Remove(Creature creature, Point position)
        {
            if (_mapObjects.ContainsKey(position))
            {
                _mapObjects[position].Remove(creature);

                if (_mapObjects[position].Count == 0)
                {
                    _mapObjects.Remove(position);
                }
            }
        }

        public override List<Creature>? At(int x, int y)
        {
            var position = new Point(x, y);
            return _mapObjects.ContainsKey(position) ? _mapObjects[position] : null;
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        }

        public override Point Next(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X, p.Y - 1),
                Direction.Down => new Point(p.X, p.Y + 1),
                Direction.Left => new Point(p.X - 1, p.Y),
                Direction.Right => new Point(p.X + 1, p.Y),
                _ => p
            };
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X + 1, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y - 1),
                Direction.Right => new Point(p.X + 1, p.Y + 1),
                Direction.Down => new Point(p.X - 1, p.Y + 1),
                _ => p
            };
        }
    }
}
