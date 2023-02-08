using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEater
{
    internal class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeigh)
        {
            wallList = new List<Figure>();

            HorizontalLine TopLine = new HorizontalLine(0, 38, 0, '+');
            HorizontalLine BotLine = new HorizontalLine(0, 38, 24, '+');
            VerticalLine LeftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine RightLine = new VerticalLine(0, 24, 38, '+');

            wallList.Add(TopLine);
            wallList.Add(BotLine);
            wallList.Add(LeftLine);
            wallList.Add(RightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList) wall.Draw();
        }
    }
}
