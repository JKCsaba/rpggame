using rpggame.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpggame.GameLoop
{
    public class GameManager
    {
        private Player _player;
        private ShopManager _shopManager;

        private bool gameisactive;
        string command;

        public GameManager()
        {
            Start();
        }

        private void Start()
        {
            Titlescreen();
            MainMenu();
        }

        private void Titlescreen()
        {
            Console.WriteLine("__      ___  _ ___ ___ ___ ___ ___                  \r\n\\ \\    / / || |_ _/ __| _ \\ __| _ \\  _ _ _ __  __ _ \r\n \\ \\/\\/ /| __ || |\\__ \\  _/ _||   / | '_| '_ \\/ _` |\r\n  \\_/\\_/ |_||_|___|___/_| |___|_|_\\ |_| | .__/\\__, |\r\n                                        |_|   |___/ " +
                "\n Welcome to WHISPER rpg!");
        }

        private void MainMenu()
        {
            bool chosen = false;

            while (!chosen)
            {
                Console.WriteLine("1: Start a new game" + "\n2: Load a save" + "\n3: Quit");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Intro();
                        MainLoop();
                        chosen = true;
                        break;
                    case "2":
                        LoadSave();
                        chosen = true;
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option! choose again.\n");
                        break;

                }
            }
        }
        private void GameOverscreen()
        {
            Console.WriteLine("\nYou have\n ____  _          _ \r\n|  _ \\(_) ___  __| |\r\n| | | | |/ _ \\/ _` |\r\n| |_| | |  __/ (_| |\r\n|____/|_|\\___|\\__,_|\n");
            Console.WriteLine(_player.Stats());
            Console.WriteLine();
            MainMenu();
        }
        private void Intro()
        {
            Console.Clear();
            Console.WriteLine("You slowly wake up from your slumber in a forest");
            Console.WriteLine("...");
            Console.WriteLine("You don't know who you are, or how you got here");
            Console.WriteLine("...");
            Console.WriteLine("You don't even know your own name!?");
            Thread.Sleep(2000);
            Console.WriteLine("You decide to give a name to yourself: (Enter your name and hit enter)");
            string playername = Console.ReadLine();
            _player = new(playername);
            _shopManager = new();
            Console.WriteLine($"Welcome, {_player.Name}, your Journey begins.");
            Console.WriteLine("End of introduction. Type help to see the list of commands.\n");
            Thread.Sleep(1000);
            Console.WriteLine(_player.Stats());
        }

        private void MainLoop()
        {
            gameisactive = true;
            Commandmanager _commandmanager = new Commandmanager();

            while (gameisactive)
            {
                ConsoleColor normalcolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">");
                command = Console.ReadLine();
                Console.ForegroundColor = normalcolor;
                string result = _commandmanager.ProcessCommand(_player,_shopManager, command);
                Console.WriteLine("\n" + result);

                if (!_player.Alive)
                {
                    gameisactive= false;
                    GameOverscreen();
                }
            }
        }
        private void LoadSave()
        {
            Console.WriteLine("The savesystem is not yet implemented!");
            MainMenu();
        }
        
    }
}