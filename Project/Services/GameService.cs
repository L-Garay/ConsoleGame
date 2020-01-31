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
        System.Console.WriteLine($"- {item.Name}");
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
      var ItemToTake = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (ItemToTake != null)
      {

        _game.CurrentPlayer.Inventory.Add(ItemToTake);
        _game.CurrentRoom.Items.Remove(ItemToTake);
        Messages.Add($"Successfully added {ItemToTake.Name} to your inventory!");
        return;
      }
      else
      {
        Messages.Add("Unable to find the item you specified");
        return;
      }
    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      var ItemToUse = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      if (ItemToUse == null)
      {

        Messages.Add("Unable to find that item");
        return;
      }
      else if (ItemToUse.Name.ToLower() == "key" && _game.CurrentRoom.LockedExits.ContainsKey(ItemToUse))
      {
        var NowUnlocked = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked.Key, NowUnlocked.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        Messages.Add("Successfully used item!");
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "card" && _game.CurrentRoom.LockedExits.ContainsKey(ItemToUse))
      {
        var NowUnlocked1 = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked1.Key, NowUnlocked1.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "shovel" && _game.CurrentRoom.Name == "Manager's Office")
      {
        System.Console.WriteLine("You swing the shovel as hard as you can, and it get's lodged in your brother's skull; he is dead.");
        System.Console.WriteLine("As his body hits the ground, you hear the slight jingle of what is probably a keychain.  And sure enough, as he does a final death roll, a keychain falls out.");
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "flashlight" && _game.CurrentRoom.Name == "Sleeping Quaters")
      {
        _game.CurrentRoom.Description = "You shine the light around the room and see that most of it is either broken or usesless.  However, upon closer inspection, you see that some of the items are stacked in front of an area on the far wall.";
        var NowUnlocked2 = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked2.Key, NowUnlocked2.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        System.Console.WriteLine(_game.CurrentRoom.Description);
        System.Console.WriteLine("");

      }
      else
      {
        Messages.Add("You can't use that item here.");
        return;
      }
    }
  }
}