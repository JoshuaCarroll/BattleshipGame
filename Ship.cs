using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipRaygun
{
    public class Ship
    {
        public int StartX = -1;
        public int StartY = -1;
        public int EndX = -1;
        public int EndY = -1;
        public int HitsToSink = 2;

        public Ship()
        {
            HitsToSink = 2;
        }
    }
}