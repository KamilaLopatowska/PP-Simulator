using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace Simulator;

public class Simulation
{
    private int _currentMoveIndex = 0;

    public Map Map { get; }

    public List<Creature> Creatures { get; }

    public List<Point> Positions { get; }

    public string Moves { get; }

    public bool Finished { get; private set; } = false;

    public Creature CurrentCreature => Creatures[_currentMoveIndex % Creatures.Count];

    public string CurrentMoveName
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Simulation is finished.");
            return Moves[_currentMoveIndex].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (creatures.Count != positions.Count)
            throw new ArgumentException("Number of creatures must match number of starting positions.");
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves string cannot be empty or null.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
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
        Creature currentCreature = CurrentCreature;

        Point newPosition = Map.Next(currentCreature.Position, direction);

        if (Map.Exist(newPosition))
        {
            Map.Remove(currentCreature, currentCreature.Position);
            currentCreature.Position = newPosition;
            Map.Add(currentCreature, newPosition);
        }

        _currentMoveIndex++;

        if (_currentMoveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
