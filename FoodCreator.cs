using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEater
{
    internal class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;

        Random rnd = new Random();

        public FoodCreator(int mapWindth, int mapHeight, char sym)
        {
            this.mapWidth = mapWindth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = rnd.Next(2, mapWidth - 2);
            int y = rnd.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
