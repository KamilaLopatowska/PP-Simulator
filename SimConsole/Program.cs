using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie mapy 5x5
            SmallSquareMap map = new SmallSquareMap(5);

            // Tworzenie listy stworów
            List<Creature> creatures = new List<Creature>
            {
                new Orc("Gorbag"),
                new Elf("Elandor")
            };

            // Określenie pozycji dla stworów
            List<Point> points = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1)
            };

            // Określenie sekwencji ruchów
            string moves = "dlrludl";

            // Tworzenie instancji symulacji
            Simulation simulation = new Simulation(map, creatures, points, moves);

            // Tworzenie wizualizatora mapy
            MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

            // Uruchomienie symulacji
            while (!simulation.Finished)
            {
                // Wyświetlanie mapy przed ruchem
                Console.Clear();
                mapVisualizer.Draw();
                Console.WriteLine($"Current Creature: {simulation.CurrentCreature.Name}");
                Console.WriteLine($"Current Move: {simulation.CurrentMoveName}");
                Console.WriteLine("Press any key for next move...");
                Console.ReadKey(); // Czekaj na naciśnięcie klawisza

                // Wykonaj turę
                simulation.Turn();
            }

            // Po zakończeniu symulacji
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine("Simulation finished.");
        }
    }
}
