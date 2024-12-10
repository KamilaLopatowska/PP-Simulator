using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace Simulator;

public class Simulation
{
    private int _currentMoveIndex = 0;

    public Map Map { get; }

    public List<IMappable> IMappables { get; }

    public List<Point> Positions { get; }

    public string Moves { get; }

    public bool Finished { get; private set; } = false;

    public IMappable CurrentIMappable => IMappables[_currentMoveIndex % IMappables.Count];

    public string CurrentMoveName
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Simulation is finished.");
            return Moves[_currentMoveIndex].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
            throw new ArgumentException("IMappables list cannot be empty.");
        if (mappables.Count != positions.Count)
            throw new ArgumentException("Number of mappables must match number of starting positions.");
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves string cannot be empty or null.");

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Cannot make a move; the simulation is finished.");

        char currentMoveChar = Moves[_currentMoveIndex];
        var directions = DirectionParser.Parse(currentMoveChar.ToString());

        if (directions.Count == 0)
        {
            _currentMoveIndex++;
            return; // Invalid move; skip turn.
        }

        Direction direction = directions[0];
        IMappable currentIMappable = CurrentIMappable;

        Point newPosition = Map.Next(currentIMappable.Position, direction);

        if (Map.Exist(newPosition))
        {
            Map.Remove(currentIMappable, currentIMappable.Position);
            currentIMappable.Position = newPosition;
            Map.Add(currentIMappable, newPosition);
        }

        _currentMoveIndex++;

        if (_currentMoveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
