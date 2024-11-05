namespace Simulator;

public abstract class Creature
{
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
    public abstract void SayHi();

    public abstract string Info { get; }

    public abstract int Power { get; }

    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }
    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }
    public void Go(string directionString)
    {
        var directions = DirectionParser.Parse(directionString);
        Go(directions);
    }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
