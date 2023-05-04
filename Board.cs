using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BattleshipRaygun
{
    public class Board
    {
        public int Height;
        public int Width;
        public string[,] Cells;
        public Ship Ship1;
        public Ship Ship2; 

        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            Cells = new string[width, height];

            Ship1 = new Ship();
            placeShip(Ship1);
            Cells[Ship1.StartX, Ship1.StartY] = "1";
            Cells[Ship1.EndX, Ship1.EndY] = "1";

            Ship2 = new Ship();
            do {
                placeShip(Ship2);
            } while (shipsOverlap());

            Cells[Ship2.StartX, Ship2.StartY] = "2";
            Cells[Ship2.EndX, Ship2.EndY] = "2";
        }

        private void placeShip(Ship ship)
        {
            Random rnd = new Random();
            ship.StartX = rnd.Next(Width-1);

            rnd = new Random();
            ship.StartY = rnd.Next(Height-1);
            Debug.WriteLine(ship.StartX + "," + ship.StartY);

            rnd = new Random();
            int direction = rnd.Next(100);

            if (direction <= 50)
            {
                //Vertical
                if (Height > ship.StartY)
                {
                    ship.EndY = ship.StartY + 1;
                    ship.EndX = ship.StartX;
                }
                else // It selected the top line
                {
                    ship.EndY = ship.StartY - 1;
                    ship.EndX = ship.StartX;
                }
            }
            else
            {
                //Horizontal
                if (Width > ship.StartX)
                {
                    ship.EndX = ship.StartX + 1;
                    ship.EndY = ship.StartY;
                }
                else // It selected the top line
                {
                    ship.EndX = ship.StartX - 1;
                    ship.EndY = ship.StartY;
                }
            }
        }

        private bool shipsOverlap()
        {
            if (
                Ship1.StartX == Ship2.StartX || 
                Ship1.StartX == Ship2.EndX ||
                Ship1.StartY == Ship2.StartY ||
                Ship1.StartY == Ship2.EndY ||
                Ship1.EndX == Ship2.StartX ||
                Ship1.EndX == Ship2.EndX ||
                Ship1.EndY == Ship2.StartY ||
                Ship1.EndY == Ship2.EndY)
            {
                return true;
            }
            else { return false; }
        }
    }
}