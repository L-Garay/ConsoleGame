using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
      Setup();
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        Messages.Add("Travelling...");
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        Messages.Add("Arrived");
        Messages.Add(_game.CurrentRoom.Description);
        return;
      }
      Messages.Add("You can't go that way");
    }
    public void Help()
    {
      System.Console.WriteLine("Here are a list of your commands:");
      System.Console.WriteLine("");
      System.Console.WriteLine("1) Go <direction>");
      System.Console.WriteLine("");
      System.Console.WriteLine("2) Take <item>");
      System.Console.WriteLine("");
      System.Console.WriteLine("3) Use <item>");
      System.Console.WriteLine("");
      System.Console.WriteLine("4) Look");
      System.Console.WriteLine("");
      System.Console.WriteLine("5) Inventory");
      System.Console.WriteLine("");
      System.Console.WriteLine("6) Quit");
      System.Console.WriteLine("");
      Messages.Add("Type in any of those commands");
    }

    public void Inventory()
    {
      System.Console.WriteLine("Here is you current inventory.");
      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        System.Console.WriteLine($"- {item}");
      }
      Messages.Add("Remember, only certain items can be used in certain rooms/ on certain doors.");
      return;
    }

    public void Look()
    {
      System.Console.WriteLine(_game.CurrentRoom.Description);
      return;
    }

    public void Setup()
    {
      Messages.Add(_game.CurrentRoom.Description);
    }
    public void Setup(string player)
    {

    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}