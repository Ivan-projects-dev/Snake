﻿using System;

namespace Snake
{
    class Snake
    {
        public int[] X { private set; get; }

        public int[] Y { private set; get; }

        public int Length { set; get; }

        public enum Direction { Left, Right, Top, Bottom }

        Printer p = new Printer();

        public void Restart()
        {
            X = new int[50];
            Y = new int[50];
            X[0] = X[1] = X[2] = Game.Width / 2;
            Y[0] = Game.Height / 2;
            Y[1] = Game.Height / 2 + 1;
            Y[2] = Game.Height / 2 + 2;
            Length = 3;
        }

        public void Shift(Direction direction)
        {
            for (int i = Length + 1; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            X[0] -= Convert.ToInt32(direction == Direction.Left);
            X[0] += Convert.ToInt32(direction == Direction.Right);
            Y[0] -= Convert.ToInt32(direction == Direction.Top);
            Y[0] += Convert.ToInt32(direction == Direction.Bottom);
        }

        void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Length; i++)
            {
                p.Print(X[i], Y[i], "■");
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (X[Length] != 0)
            {
                p.Print(X[Length], Y[Length], "\0");
            }
        }

        public void Rules(ref bool IsLost)
        {
            Draw();
            if (X[0] <= 0 || X[0] >= Game.Width + 1 || Y[0] <= 0 || Y[0] >= Game.Height + 1)
            {
                IsLost = true;
            }
            for (int i = Length; i >= 2; i--)
            {
                if (X[0] == X[i - 1] && Y[0] == Y[i - 1])
                {
                    IsLost = true;
                }
            }
        }
    }
}