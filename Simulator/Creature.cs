using Simulator.Maps;
namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; set; }
    public void InitMapAndPosition(Map map, Point position) { }




    private string _name = "Unknown";
    private int _level = 1;

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = Validator.Shortener(name, 3, 25, '#');
        Level = Validator.Limiter(level, 1, 10);
    }

    public string Name
    {
        get => _name;
        set => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        set => _level = Validator.Limiter(value, 1, 10);
    }
    public string Greeting() => $"Hi, I'm {Name}, my level is {Level}";

    public abstract string Info { get; }

    public abstract int Power { get; }

    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}"; //zgodnie z regułami mapy

    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i =0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public string[] Go(string directionString)
    {
        if (string.IsNullOrWhiteSpace(directionString))
            throw new ArgumentException("Direction string cannot be null or empty.");

        var directions = DirectionParser.Parse(directionString);
        if (directions == null || directions.Count == 0)
            throw new ArgumentException("Direction string contains no valid directions.");

        return Go(directions.ToArray());
    }


    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
