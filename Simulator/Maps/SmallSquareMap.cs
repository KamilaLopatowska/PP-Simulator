﻿using System;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public readonly int Size;

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(null, $"Rozmiar mapy jest nieprawidłowy - wynosi {size}. Ma być w przedziale od 5 do 20");
            else
            {
                Size = size;
                Console.WriteLine($"Mapa ma rozmiar {size}");
            }
        }
        public override bool Exist(Point p)
        {
            Rectangle mapArea = new(0, 0, Size - 1, Size - 1);
            return mapArea.Contains(p);
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
}