namespace Simulator;

public class Orc : Creature
{
    public Orc() { } 
    private int _rage;

    public int Rage
    {
        get => _rage;
        set
        {
            _rage = Validator.Limiter(value, 0, 10);
        }
    }

    public Orc(string name, int level = 1, int rage = 0) : base(name, level)
    {
        Name = Validator.Shortener(name, 3, 25, '#'); 
        Level = Validator.Limiter(level, 1, 10); 
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

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name} [{Level}][{Rage}]";

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
    );
}
