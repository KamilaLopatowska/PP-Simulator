using Simulator.Maps;

namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting simulator\n");
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
        Lab5a();
        Lab5b();
    }

    static void Lab5a()
    {
        Console.WriteLine("Testowanie tworzenia prostokątów:");

        // tworzenie prostokąta z luźnych współrzędnych
        try
        {
            Rectangle a = new Rectangle(5, 5, 1, 3); 
            Console.WriteLine("rect1: " + a); // (1, 3):(5, 5)
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Błąd przy tworzeniu rect1: " + e.Message);
        }

        // tworzenie prostokąta z użyciem punktów
        try
        {
            Point p1 = new Point(2, 2);
            Point p2 = new Point(6, 6);
            Rectangle b = new Rectangle(p1, p2); 
            Console.WriteLine("rect2: " + b); //(2, 2):(6, 6)
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Błąd przy tworzeniu rect2: " + e.Message);
        }

        // próba utworzenia "chudego" prostokąta (punkty współliniowe)
        try
        {
            Rectangle c = new Rectangle(4, 4, 4, 8); 
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Błąd przy tworzeniu rect3: " + e.Message); // komunikat o współliniowości
        }

        // sprawdzenie, czy prostokąt zawiera punkt
        Rectangle d = new Rectangle(1, 1, 5, 5);
        Point pointInside = new Point(3, 3);
        Point pointOutside = new Point(6, 6);

        Console.WriteLine("rect4: " + d); // (1,1):(5,5)
        Console.WriteLine("Czy rect4 zawiera punkt (3,3)? " + d.Contains(pointInside)); // true
        Console.WriteLine("Czy rect4 zawiera punkt (6,6)? " + d.Contains(pointOutside)); // false
    }

    static void Lab5b()
    {
        Console.WriteLine("Test klasy SmallSquareMap"); // oczekiwanie wyniki w komentarzach
        try
        {
            // test rozmiarów mapy

            SmallSquareMap m1 = new(10);

            // test metody exist

            Point p1 = new(2, 5);
            Point p2 = new(11, 15);

            Console.WriteLine(m1.Exist(p1)); //true
            Console.WriteLine(m1.Exist(p2)); //false

            // test metody next 

            Point p3 = new(9, 8);
            Point p4 = new(0, 0);
            Console.WriteLine(m1.Next(p1, Direction.Left)); // (1,5)
            Console.WriteLine(m1.Next(p1, Direction.Up)); // (2,6)
            Console.WriteLine(m1.Next(p3, Direction.Right)); // (9,8)
            Console.WriteLine(m1.Next(p4, Direction.Left)); // (0,0)

            // test metody nextdiagonal

            Console.WriteLine(m1.NextDiagonal(p3, Direction.Up)); // (9,8)
            Console.WriteLine(m1.NextDiagonal(p4, Direction.Down)); // (0,0)
            Point p5 = new(8, 8);
            Console.WriteLine(m1.NextDiagonal(p5, Direction.Up)); // (9,9)
            Console.WriteLine(m1.NextDiagonal(p1, Direction.Down)); // (1,4)
        }
        catch (ArgumentOutOfRangeException a)
        {
            Console.WriteLine(a.Message);
        }
        try
        {
            SmallSquareMap m2 = new(25);
            SmallSquareMap m3 = new(5);
            SmallSquareMap m4 = new(20);
        }
        catch (ArgumentOutOfRangeException a)
        {
            Console.WriteLine(a.Message); //exception tylko do m2 - rozmiaru 25
        }

    }
}
