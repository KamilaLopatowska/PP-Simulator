using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size => SizeX; 

        public SmallTorusMap(int size) : base(size, size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size),
                    $"Rozmiar mapy jest nieprawidłowy - wynosi {size}. Ma być w przedziale od 5 do 20.");
            }

            Console.WriteLine($"Mapa ma rozmiar {size}x{size}");
        }

        public override void Add(Creature creature, Point position)
        {
            throw new NotImplementedException("Dodawanie stworzeń do toroidalnej mapy jeszcze nie zaimplementowane.");
        }

        public override List<Creature>? At(int x, int y)
        {
            throw new NotImplementedException("Pobieranie stworzeń z toroidalnej mapy jeszcze nie zaimplementowane.");
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            return new Point(
                (nextPoint.X + SizeX) % SizeX,
                (nextPoint.Y + SizeY) % SizeY
            );
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            return new Point(
                (nextPoint.X + SizeX) % SizeX,
                (nextPoint.Y + SizeY) % SizeY
            );
        }

        public override void Remove(Creature creature, Point position)
        {
            throw new NotImplementedException("Usuwanie stworzeń z toroidalnej mapy jeszcze nie zaimplementowane.");
        }
    }
}
