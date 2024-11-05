namespace Simulator;

public class Elf : Creature
{
    public Elf() { } 
    private int _agility;

    public int Agility
    {
        get => _agility;
        set
        {
            _agility = Validator.Limiter(value, 0, 10); 
        }
    }

    public Elf(string name, int level = 1, int agility = 0) : base(name, level)
    {
        Name = Validator.Shortener(name, 3, 25, '#'); 
        Level = Validator.Limiter(level, 1, 10); 
        Agility = agility; 
    }

    private int singCount = 0;
    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");
        if (singCount % 3 == 0)
        {
            Agility++;
        }
    }

    public override int Power => 8 * Level + 2 * Agility;

    public override string Info => $"{Name} [{Level}][{Agility}]";

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );
}
