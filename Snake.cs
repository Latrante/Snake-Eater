using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeEater
{
    internal class Snake : Figure
    {
        Direction direction;
        public Snake(Point tale, int length, Direction direction)
        { 
            this.direction = direction;
            pList = new List<Point> ();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tale);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail= pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add (head);

            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point NextPoint = new Point(head);
            NextPoint.Move(1, direction);
            return NextPoint;
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i =0; i<pList.Count-2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                if (direction != Direction.RIGHT)
                    direction = Direction.LEFT;
                else direction = Direction.RIGHT;

            else if (key == ConsoleKey.RightArrow)
                if (direction != Direction.LEFT)
                    direction = Direction.RIGHT;
                else direction = Direction.LEFT;

            else if (key == ConsoleKey.UpArrow)
                if (direction != Direction.DOWN)
                    direction = Direction.UP;
                else direction = Direction.DOWN;

            else if (key == ConsoleKey.DownArrow)
                if (direction != Direction.UP)
                    direction = Direction.DOWN;
                else direction = Direction.UP;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
