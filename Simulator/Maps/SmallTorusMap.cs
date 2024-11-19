using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    public readonly Rectangle mapArea;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(null, $"Rozmiar mapy jest nieprawidłowy - wynosi {size}. Ma być w przedziale od 5 do 20");
        else
        {
            Size = size;
            mapArea = new Rectangle(0, 0, Size - 1, Size - 1);
            Console.WriteLine($"Mapa ma rozmiar {size}");
        }
    }

    public override bool Exist(Point p)
    {
        return mapArea.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d); 
        return new Point(
            (nextPoint.X + Size) % Size, 
            (nextPoint.Y + Size) % Size  
        );
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d); 
        return new Point(
            (nextPoint.X + Size) % Size,
            (nextPoint.Y + Size) % Size  
        );
    }
}
