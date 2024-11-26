using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private readonly Dictionary<Point, List<Creature>> _creaturesAtPoints = new();

    public SmallSquareMap(int size) : base(size, size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size),
                $"Rozmiar mapy jest nieprawidłowy - wynosi {size}. Ma być w przedziale od 5 do 20.");
        }

    }

    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Pozycja znajduje się poza mapą.");

        if (!_creaturesAtPoints.ContainsKey(position))
        {
            _creaturesAtPoints[position] = new List<Creature>();
        }

        _creaturesAtPoints[position].Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        if (!_creaturesAtPoints.ContainsKey(position))
            throw new ArgumentException("Brak stworów na tej pozycji.");

        var creatures = _creaturesAtPoints[position];
        if (creatures.Remove(creature) && creatures.Count == 0)
        {
            _creaturesAtPoints.Remove(position);
        }
    }

    public override List<Creature>? At(int x, int y)
    {
        var position = new Point(x, y);
        if (_creaturesAtPoints.ContainsKey(position))
        {
            return _creaturesAtPoints[position];
        }
        return null;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return Exist(nextPoint) ? nextPoint : p;
    }
}
