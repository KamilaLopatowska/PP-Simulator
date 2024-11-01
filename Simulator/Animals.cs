﻿public class Animals
{
    private string _description = "Unknown";

    public string? Description
    {
        get => _description;
        init
        {
            value = value?.Trim() ?? "Unknown";

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            else if (value.Length > 15)
            {
                value = value.Substring(0, 15).TrimEnd();
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value[1..];
            }

            _description = value;
        }
    }
    public uint Size { get; set; } = 3;

    public string Info
    { 
        get { return $"{Description} <{Size}>"; }
    }
}