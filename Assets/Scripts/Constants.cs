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
            // Enemies
            public const int NUM_OF_ENEMIES = 20;
            public const int ENEMY_WIDTH = 1; 
            public const float ENEMY_SPEED = -0.1f;
            
            // Bounds of the world
            public const int MIN_X = -50;
            public const int MAX_X = 50;
            public const int MIN_Y = 0;
            public const int MAX_Y = 100;
            public const int MIN_Z = -50;
            public const int MAX_Z = 50;
        }

    }
}
