namespace Simulator;
public class Animals
{
    private string _description = "Unknown";

    public string? Description
    {
        get => _description;
        init
        {
            Validator.Shortener(_description, 3, 15, '#');
        }
    }
    public uint Size { get; set; } = 3;

    public string Info
    { 
        get { return $"{Description} <{Size}>"; }
    }
}