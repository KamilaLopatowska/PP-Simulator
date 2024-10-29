namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level; 

    public string Name
    {
        get => _name;
        init
        {
            value = value?.Trim() ?? "Unknown";

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            else if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value[1..];
            }

            _name = value; 
        }
    }

    public int Level
    {
        get => _level; 
        set 
        {
            if (value < 1)
            {
                _level = 1; 
            }
            else if (value > 10)
            {
                _level = 10; 
            }
            else
            {
                _level = value; 
            }
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name; 
        Level = level; 
    }

    public Creature() { }

    public void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name} my level is {Level}.");

    public string Info => $"{Name} [{Level}]";

    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }
}
