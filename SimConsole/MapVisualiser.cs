using System;
using System.Collections.Generic;
using System.Drawing;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class MapVisualizer
    {
        private readonly Map _map;

        public MapVisualizer(Map map)
        {
            _map = map;
        }

        public void Draw()
        {
            Console.Clear();

            for (int y = 0; y < _map.SizeY; y++)
            {

                // top
                if (y == 0)
                {
                    for (int x = 0; x < _map.SizeX * 2; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write(Box.TopLeft);
                        }
                        else if (x % 2 == 0)
                        {
                            Console.Write(Box.TopMid);
                        }
                        else if (x == _map.SizeX * 2 - 1)
                        {
                            Console.Write(Box.TopRight);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < _map.SizeX * 2; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write(Box.MidLeft);
                        }
                        else if (x % 2 == 0)
                        {
                            Console.Write(Box.TopMid);
                        }
                        else if (x == _map.SizeX * 2 - 1)
                        {
                            Console.Write(Box.MidRight);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }

                Console.WriteLine();

                // middle
                for (int x = 0; x < _map.SizeX * 2; x++)
                {
                    if (x == 0)
                    {
                        Console.Write(Box.Vertical);
                    }

                    if (x % 2 == 0)
                    {
                        Console.Write(Box.Vertical);
                    }
                    else
                    {
                        // Console.Write(" ");
                    }

                    if (x == _map.SizeX * 2 - 1)
                    {
                        Console.Write(Box.Vertical);
                    }
                }
                Console.WriteLine();

                if (y != _map.SizeY - 1)
                {
                    //bottom
                    for (int x = 0; x < _map.SizeX * 2; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write(Box.MidLeft);
                        }
                        else if (x % 2 == 0)
                        {
                            Console.Write(Box.Cross);
                        }
                        else if (x == _map.SizeX * 2 - 1)
                        {
                            Console.Write(Box.MidRight);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < _map.SizeX * 2; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write(Box.BottomLeft);
                        }
                        else if (x % 2 == 0)
                        {
                            Console.Write(Box.BottomMid);
                        }
                        else if (x == _map.SizeX * 2 - 1)
                        {
                            Console.Write(Box.BottomRight);
                        }
                        else
                        {
                            Console.Write(Box.Horizontal);
                        }
                    }
                }
            }
        }
    }
}