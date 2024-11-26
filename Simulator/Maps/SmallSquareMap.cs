using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        // Konstruktor klasy, inicjalizujący mapę jako kwadrat o określonym rozmiarze
        public SmallSquareMap(int size) : base(size, size)
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
            throw new NotImplementedException("Dodawanie stworzeń do mapy jeszcze nie zaimplementowane.");
        }

        public override List<Creature>? At(int x, int y)
        {
            throw new NotImplementedException("Pobieranie stworzeń z mapy jeszcze nie zaimplementowane.");
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

        public override void Remove(Creature creature, Point position)
        {
            throw new NotImplementedException("Usuwanie stworzeń z mapy jeszcze nie zaimplementowane.");
        }
    }
}
