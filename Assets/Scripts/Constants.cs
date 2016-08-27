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
            public const int NUM_OF_ENEMIES = 10;
            public const int ENEMY_WIDTH = 5;
            public const int ENEMY_MIN_SIZE = 1;
            public const int ENEMY_MAX_SIZE = 5;
            public const float ENEMY_SPEED = -0.1f;
            
            // Bounds of the world
            public const int MIN_X = -25;
            public const int MAX_X = 25;
            public const int MIN_Y = -25;
            public const int MAX_Y = 25;
            public const int MIN_Z = -50;
            public const int MAX_Z = 50;
        }

        public static class Tags
        {
            public const string ENEMY_TAG = "Enemy";
        }
    }
}
