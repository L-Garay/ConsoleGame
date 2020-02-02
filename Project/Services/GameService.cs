using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public bool playing { get; set; } = true;
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
      Messages.Add("Here are a list of your commands:");
      Messages.Add("");
      Messages.Add("1) Go <direction>");
      Messages.Add("");
      Messages.Add("2) Take <item>");
      Messages.Add("");
      Messages.Add("3) Use <item>");
      Messages.Add("");
      Messages.Add("4) Look (will display room description)");
      Messages.Add("5) Search (will display items in room)");
      Messages.Add("");
      Messages.Add("5) Inventory");
      Messages.Add("");
      Messages.Add("6) Quit");
      Messages.Add("");
      Messages.Add("Type in any of those commands");
    }

    internal void Search()
    {
      if (_game.CurrentRoom.Name == "Tool Shed")
      {
        Messages.Add($"As you step into the doorway to see what's inside, you can see that there's not much; and what is left is all either broken or useless.  As you turn around however, you notice a rusty shovel laying in the grass.");
        return;
      }
      else if (_game.CurrentRoom.Name == "Sleeping Quarters" && _game.CurrentPlayer.Inventory.Exists(f => f.Name == "Flashlight"))
      {
        Messages.Add("You stand in the doorway and turn on the flashlight, it's not the brightest but it works well enough.  You shine it around the room as you enter, there's garbage and broken items all around with old metal bed frames scattered about.  Most of the windows have metal bars or some sort of makeshift cover over them.  There's not much in the room anymore, although you notice that theres a section of furniture with very little dust on them.  And they are clustered up against a section of wall on the south side of the room.");
        return;
      }
      else if (_game.CurrentRoom.Name == "Sleeping Quarters")
      {
        Messages.Add("The room is pitch black, and dead silent. There's got to be something of use in there, but it's impossible to see. Maybe there's a light switch somewhere.");
        return;
      }
    }

    public void Inventory()
    {
      Messages.Add("Here is you current inventory.");
      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"- {item.Name}");
      }
      Messages.Add("Remember, only certain items can be used in certain rooms/ on certain doors.");
      return;
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Description);
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
        if (_game.CurrentRoom.Name == "Manager's Office")
        {
          _game.CurrentRoom.Exits.Add(NowUnlocked1.Key, NowUnlocked1.Value);
          _game.CurrentRoom.LockedExits.Remove(ItemToUse);
          Messages.Add("You slowly bend down a grab the keychain off the body.  There appears to be car keys on it as well.  You quickly download the files from the computer there in the office and use the card to unlock the door and begin to walkt out");
          return;
        }
        else if (_game.CurrentRoom.Name == "Courtyard")
        {
          _game.CurrentRoom.Exits.Add(NowUnlocked1.Key, NowUnlocked1.Value);
          _game.CurrentRoom.LockedExits.Remove(ItemToUse);
          Messages.Add("You run through the courtyard and down the dirt driveway towards where you remember you saw the pickup.");
          return;
        }
      }
      else if (_game.CurrentRoom.Name == "Car")
      {
        System.Console.WriteLine("You get in the car and try the key. It works!  There's not much gas but it should be just enough to get out of here.  You quickly speed off, wondering if anyone will ever believe your story.  Do you even believe it yourself...");
        playing = false;

      }
      else if (ItemToUse.Name.ToLower() == "shovel" && _game.CurrentRoom.Name == "Manager's Office")
      {
        Messages.Add("You swing the shovel as hard as you can, and it get's lodged in your brother's skull; he is dead.");
        Messages.Add("As his body hits the ground, you hear the slight jingle of what is probably a keychain.  And sure enough, as he does a final death roll, a keychain with a card and some sort of key falls out.");
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "flashlight" && _game.CurrentRoom.Name == "Sleeping Quarters")
      {
        _game.CurrentRoom.Description = "You shine the light around the room and see that most of it is either broken or usesless.  However, upon closer inspection, you see that some of the items are stacked in front of an area on the far wall.";
        var NowUnlocked2 = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked2.Key, NowUnlocked2.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        Messages.Add(_game.CurrentRoom.Description);
        Messages.Add("");

      }
      else
      {
        Messages.Add("You can't use that item here.");
        return;
      }
    }
  }
}