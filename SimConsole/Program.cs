using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lab7a();
            Lab7b();
        }

        public static void Lab7a()
        {
            SmallSquareMap map = new SmallSquareMap(5);

            List<Creature> creatures = new List<Creature>
            {
                new Orc("Gorbag"),
                new Elf("Elandor")
            };

            List<Point> points = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1)
            };

            string moves = "dlrludl";

            Simulation simulation = new Simulation(map, creatures, points, moves);

            MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

            while (!simulation.Finished)
            {
                Console.Clear();
                mapVisualizer.Draw();
                Console.WriteLine($"Current Creature: {simulation.CurrentCreature.Name}");
                Console.WriteLine($"Current Move: {simulation.CurrentMoveName}");
                Console.WriteLine("Press any key for next move...");
                Console.ReadKey();

                simulation.Turn();
            }
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine("Simulation finished.");
        }
        public static void Lab7b()
        {
            // Tworzenie mapy 7x7
            SmallSquareMap map = new SmallSquareMap(7);

            // Lista stworzeń
            List<Creature> creatures = new List<Creature>
    {
        new Orc("Azog"),
        new Elf("Galadriel"),
        new Elf("Legolas")
    };

            // Lista punktów startowych
            List<Point> points = new List<Point>
    {
        new Point(0, 0),
        new Point(6, 0),
        new Point(3, 3)
    };

            // Zestaw ruchów
            string moves = "ulurrdllur";

            // Tworzenie symulacji
            Simulation simulation = new Simulation(map, creatures, points, moves);

            // Inicjalizacja wizualizatora mapy
            MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

            // Pętla symulacji
            while (!simulation.Finished)
            {
                Console.Clear();
                mapVisualizer.Draw();
                Console.WriteLine($"Current Creature: {simulation.CurrentCreature.Name}");
                Console.WriteLine($"Current Move: {simulation.CurrentMoveName}");
                Console.WriteLine("Press any key for next move...");
                Console.ReadKey();

                simulation.Turn();
            }
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine("Simulation finished.");
        }

    }
}

