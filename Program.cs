﻿using System;

namespace AreaTrainer
{
    static class Program
    {
        private static string _username;
        private static string _password;

        private static int _difficulty = 1;
        
        static void Startup()
        {
            Console.WriteLine("Welcome to Area Trainer!");
            Console.WriteLine();
            Console.WriteLine("Please login.");
            _username = Utils.Input("Username");
            _password = Utils.Input("Password");
            while (_password.Length < 8)
            {
                Console.Clear();
                Console.WriteLine("Password must be 8 or more characters.");
                _password = Utils.Input("Password");
            }
            Console.Clear();
        }

        static string ShapeMenu()
        {
            Console.Clear();
            Console.WriteLine("Hi " + _username + ", please choose what you would like to practice.");
            Console.WriteLine();
            Console.WriteLine("1. Squares/Rectangles");
            Console.WriteLine("2. Triangles");
            Console.WriteLine("3. Circles");
            Console.WriteLine("4. Random");
            return Utils.Input();
        }

        static string AfterMenu()
        {
            Console.Clear();
            Console.WriteLine("Would you like to continue?");
            Console.WriteLine();
            Console.WriteLine("1. Continue");
            Console.WriteLine("2. See Scores");
            Console.WriteLine("3. Exit");
            return Utils.Input();
        }
        
        static void Main(string[] args)
        {
            Startup();

            while (true)
            {
                string shape = ShapeMenu();
                Console.Clear();
                switch (shape)
                {
                    case "1":
                        Questions.Square(_difficulty);
                        break;
                    case "2":
                        Questions.Triangle(_difficulty);
                        break;
                    case "3":
                        Questions.Circle(_difficulty);
                        break;
                    case "4":
                        Questions.Random(_difficulty);
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();

                string after = AfterMenu();
                switch (after)
                {
                    case "1":
                        if (_difficulty < 3)
                        {
                            _difficulty++;
                        }
                        else
                        {
                            _difficulty = 1;
                        }
                        break;
                    case "2":
                        Score.PrintScores(_username);
                        Console.WriteLine();
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Score.SaveScore(_username);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}