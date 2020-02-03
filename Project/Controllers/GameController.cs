using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;



namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();


    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      while (_gameService.playing && _gameService.validate)
      {
        Print();
        GetUserInput();
      }
      Console.Clear();
      if (_gameService._game.CurrentRoom.Name == "Death #1" || _gameService._game.CurrentRoom.Name == "Death #2" || _gameService._game.CurrentRoom.Name == "Win Room")
      {
        System.Console.WriteLine(_gameService._game.CurrentRoom.Description);
      }
      if (_gameService._game.CurrentRoom.Name == "Manager's Office")
      {
        System.Console.WriteLine();
      }
      System.Console.WriteLine("Thanks for playing");

    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      switch (command)
      {
        case "go":
          _gameService.Go(option);
          Print();
          break;
        case "look":
          _gameService.Look();
          Print();
          break;
        case "search":
          _gameService.Search();
          Print();
          break;
        case "help":
          _gameService.Help();
          Print();
          break;
        case "inventory":
          _gameService.Inventory();
          Print();
          break;
        case "take":
          _gameService.TakeItem(option);
          Print();
          break;
        case "use":
          _gameService.UseItem(option);
          Print();
          break;
        case "quit":
          System.Console.WriteLine("Are you sure you want to do this?  There is no going back.");
          System.Console.WriteLine("");
          System.Console.WriteLine("(Please type out 'yes' or 'no'...");
          string choice = Console.ReadLine();
          if (choice == "yes")
          {
            System.Console.WriteLine("Thanks for playing, come back again!");
            _gameService.playing = false;
          }
          else
          {
            System.Console.WriteLine("That was a close one! Now back to the game");
            return;
          }
          break;
        default:
          System.Console.WriteLine("That's not an option.");
          break;
      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (var message in _gameService.Messages)
      {
        System.Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

  }
}