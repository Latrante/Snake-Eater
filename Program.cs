using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeEater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 25);
            Console.SetBufferSize(40, 25);

            Walls walls = new Walls(40, 25);
            walls.Draw();

            Point p = new Point(6, 5, '*');

            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(40, 25, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            int speed = 200;
            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();

                    if (speed > 30)
                    speed -= 10;
                }
                else snake.Move();

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }  
        }
    }
}
