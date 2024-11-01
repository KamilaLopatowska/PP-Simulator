
namespace Simulator;

public class Elf : Creature
{
    public Elf(){ } //pusty konstruktor bezparametrowy

    private int _agility;

    public int Agility
    {
        get => _agility;
        set
        {
            if (value < 0)
            {
                _agility = 0;
            }
            else if (value > 10)
            {
                _agility = 10;
            }
            else
            {
                _agility = value;
            };
        }
    }
    public Elf(string name, int level=1, int agility=0) :base(name,level)
    {   
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

    public override int Power
    {
        get { return 8 * Level + 2 * Agility; }
    }
     
public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
);
}
