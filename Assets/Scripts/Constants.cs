using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class Constants
    {
        public static class World
        {
            // NOTE:
            // Camera perspective is 0,0,0
            
            // Enemies
            public const int NUM_OF_ENEMIES = 100;
            public const int ENEMY_WIDTH = 1; 
            public const float ENEMY_SPEED = -0.1f;
            
            // Bounds of the world
            public const int MIN_X = -100;
            public const int MAX_X = 100;
            public const int MIN_Y = 0;
            public const int MAX_Y = 100;
            public const int MIN_Z = 1;
            public const int MAX_Z = 50;
        }

    }
}
