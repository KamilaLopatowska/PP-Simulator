﻿public class Animals
{
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;

    public string Info
    { 
        get { return $"Dogs <{Size}>"; }
    }
}