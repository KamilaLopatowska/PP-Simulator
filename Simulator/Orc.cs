namespace Simulator;

public class Orc : Creature
{
    public Orc() { } //pusty konstruktor bezparametrowy

    private int _rage;

    public int Rage
    {
        get => _rage;
        set
        {
            if (value < 0)
            {
                _rage = 0;
            }
            else if (value > 10)
            {
                _rage = 10;
            }
            else
            {
                _rage = value;
            };
        }
    }

    public Orc(string name, int level=1, int rage=0):base(name,level)
    {
        Rage = rage;
    }

    private int huntCount = 0;
    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");
        if (huntCount % 2 == 0)
        {
            Rage++;
        }
    }

    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
);
}