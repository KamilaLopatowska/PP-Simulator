namespace Simulator;

public class Animals
{
    private string _description = "Unknown";

    public Animals() { }

    public Animals(string description, uint size)
    {
        Description = description;
        Size = size;
    }

    public string Description
    {
        get => _description;
        set
        {
            _description = Validator.Shortener(value, 3, 15, '#');
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
