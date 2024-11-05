namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public Birds() { } 

    public Birds(string description, uint size, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }

    public override string Info
    {
        get
        {
            string flyAbility = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyAbility}) <{Size}>";
        }
    }
}
