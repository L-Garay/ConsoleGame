using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    public IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public bool playing { get; set; } = true;
    public bool validate { get; set; } = true;
    // public bool Active { get; set; } = true;
    public string NoShovelFlashlight { get; set; } = " The first thing you notice as you enter the manager's office is the giant wall of screens, some have static but others are live feeds of cameras around the building...how could they still be working, maybe there's important video evidence on there.  As you start to approach the monitors, the chair swivels around and sitting in it is this horrible looking creature with rotting skin and tattered clothing. It tries to make sounds but they are indescernable; but something about this creature does strike you.  It is wearing a silver cross around it's neck, just like the one you are wearing; just like the one your brother bought for both of you when your mother died. However you don't have much time to think, as the creature lunges out of the chair at you! You quickly raise your flashlight and swing it your onrushing brother; it's short and that allows him to close the distance to you and block it... He bites your throat and starts ripping violently, he has such strength for something so appearently frail. If only you had some tool that was longer.  Your last memories are of your deranged brother ripping your throat out...";
    public string NoShovelNoFlashlight { get; set; } = " The first thing you notice as you enter the manager's office is the giant wall of screens, some have static but others are live feeds of cameras around the building...how could they still be working, maybe there's important video evidence on there.  As you start to approach the monitors, the chair swivels around and sitting in it is this horrible looking creature with rotting skin and tattered clothing. It tries to make sounds but they are indescernable; but something about this creature does strike you.  It is wearing a silver cross around it's neck, just like the one you are wearing; just like the one your brother bought for both of you when your mother died. However you don't have much time to think, as the creature lunges out of the chair at you! You stand there in shock as your brother quickly jumps and knocks you over and begins to scrape at your face with animal like ferocity... You try to push him off but there is something unnatural about him.  If you only you had something to defend yourself; your last visions are of him snarling and beating you...";

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
        if (_game.CurrentRoom.Name == "Locked Door #1" && direction == "east")
        {
          Messages.Add("It's locked.  It's wood though, could be knocked down by something...");
          return;
        }
        else if (_game.CurrentRoom.Name == "Locked Door #2" && direction == "south")
        {
          Messages.Add("It's locked.  How am I supposed to find a key in this giant place?");
          return;
        }
        else if (_game.CurrentRoom.Name == "Car" && direction == "south")
        {
          Messages.Add("It's locked.  This looks like my brother's truck, where is that guy...");
          return;
        }
        else if (_game.CurrentRoom.Name == "Locked Door #3" && direction == "west")
        {
          Messages.Add("It's locked.  There's some sort of card reader next to the door though.");
          return;
        }
        else if (_game.CurrentRoom is DeathRoom)
        {
          EndGame();
        }
        else if (_game.CurrentRoom.Name == "Win Room")
        {
          EndGame();
        }
        Messages.Add("Arrived");
        Messages.Add(_game.CurrentRoom.Description);
        if (_game.CurrentRoom.Name == "Manager's Office" && !_game.CurrentPlayer.Inventory.Exists(i => i.Name == "Shovel") && _game.CurrentPlayer.Inventory.Exists(i => i.Name == "Flashlight") || _game.CurrentRoom.Name == "Manager's Office" && !_game.CurrentPlayer.Inventory.Exists(i => i.Name == "Shovel") && !_game.CurrentPlayer.Inventory.Exists(i => i.Name == "Flashlight"))
        {
          EndGame();
        }
        return;
      }
      Messages.Add("You can't go that way");
    }
    public void EndGame()
    {
      validate = false;
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
        Messages.Add("As you step into the doorway to see what's inside, you can see that there's not much; and what is left is all either broken or useless.  As you turn around however, you notice a rusty shovel laying in the grass.");
        Messages.Add("------------------");
        foreach (Item item in _game.CurrentRoom.Items)
        {
          Messages.Add($"-{item.Name}");
        }
        return;
      }
      else if (_game.CurrentRoom.Name == "Sleeping Quarters" && _game.CurrentPlayer.Inventory.Exists(f => f.Name == "Flashlight"))
      {
        Messages.Add("It's dark, I need to use something to see better.");
        return;
      }
      else if (_game.CurrentRoom.Name == "Sleeping Quarters")
      {
        Messages.Add("The room is pitch black, and dead silent. There's got to be something of use in there, but it's impossible to see. Most light switchs are close to the door leading into the room, so you begin to feel along the wall immediatly next to the door.  You scrape it over chipping paint until you reach the switch; it doesn't work.  However you also bump a small hook on the wall and hear a jingle, what could that be?");
        Messages.Add("------------------");
        foreach (Item item in _game.CurrentRoom.Items)
        {
          Messages.Add($"-{item.Name}");
        }
        return;
      }
      else if (_game.CurrentRoom.Name == "Kitchen")
      {
        Messages.Add("You make sure to steer clear of the rotting animals and make your way around the kitchen looking for anything useful.  All the food is either empty or spoiled, no running water, and everything is knocked over or broken. As you walk by an overturned table you hit your foot against something and it rolls slightly back and forth.  You look down and it looks like it might be a flashlight. Does it work? ");
        Messages.Add("------------------");
        foreach (Item item in _game.CurrentRoom.Items)
        {
          Messages.Add($"-{item.Name}");
        }
        return;
      }
      else if (_game.CurrentRoom.Name == "Manager's Office")
      {
        Messages.Add("You slowly approach your dead brother, or whatever the creature is, very slowly... You kick it to roll it over, and with it facing up now, you know that it's your brother.  You bend over and pick up the cross, and inscribed on the backside are your mother and your initials.  You pull out your own cross, and look at your brother's and mother's initials inscribed on it.  But that jingle you heard sounded heavier, you slowly reach into the other tattered pocket in the barely hanging on pants of your brother, and pull out a keychain with a single key and some sort of card on in.  They have to be used for something.");
        Messages.Add("------------------");
        foreach (Item item in _game.CurrentRoom.Items)
        {
          Messages.Add($"-{item.Name}");
        }
        return;
      }
      else
      {
        Messages.Add("After looking around, you conclude that there's nothing useful in the room.");
        return;
      }
    }

    public void Inventory()
    {
      if (_game.CurrentPlayer.Inventory.Count == 0)
      {
        Messages.Add("You don't have anyting in your inventory at the moment.");
        return;
      }
      else if (_game.CurrentPlayer.Inventory.Count > 0)
      {
        Messages.Add("Here is you current inventory.");
        foreach (Item item in _game.CurrentPlayer.Inventory)
        {
          Messages.Add($"- {item.Name}");
          Messages.Add("Remember, only certain items can be used in certain rooms/ on certain doors.");
        }
      }
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
      else if (ItemToUse.Name.ToLower() == "kitchenkey" && _game.CurrentRoom.LockedExits.ContainsKey(ItemToUse))
      {
        var NowUnlocked = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked.Key, NowUnlocked.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        Messages.Add("Successfully used item!");
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "carkey" && _game.CurrentRoom.LockedExits.ContainsKey(ItemToUse))
      {
        var NowUnlocked = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked.Key, NowUnlocked.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        Messages.Add("It worked! After a couple tries and a lot of cursing the thing finally started running. Now time to get out of here...");
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
          Messages.Add("You quickly rush over to the bank of monitors and look for the source computer.  You see it under the desk, how the hell is it still running? You quickly pull out the hard drive from the computer and use the card to unlock the door west of you and begin to walkt out.");
          return;
        }
      }
      else if (ItemToUse.Name.ToLower() == "carkey" && _game.CurrentRoom.Name == "Car")
      {
        System.Console.WriteLine("You get in the car and try the key. It works after a couple tries, but it does work.  There's not much gas but it should be just enough to get out of here.  You quickly speed off, wondering if anyone will ever believe your story.  Do you even believe it yourself...");
        playing = false;

      }
      else if (ItemToUse.Name.ToLower() == "shovel" && _game.CurrentRoom.Name == "Manager's Office")
      {
        Messages.Add("You swing the shovel as hard as you can, and it get's lodged in your brother's skull; he lets out an animal like scream before collapsing to the floor.");
        Messages.Add("As his body hits the ground, you hear a slight jingle.  What could that have been?");
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "shovel" && _game.CurrentRoom.Name == "Locked Door #1")
      {
        var NowUnlocked = _game.CurrentRoom.LockedExits[ItemToUse];
        _game.CurrentRoom.Exits.Add(NowUnlocked.Key, NowUnlocked.Value);
        _game.CurrentRoom.LockedExits.Remove(ItemToUse);
        Messages.Add("Successfully used item!");
        Messages.Add("You take a couple steps back, and then swing the shovel with all your might at the wooden door, it takes a couple minutes and your hands are definetely bruised, but you manage to break down the door. The shovel is useless now though, and you toss it to the side; and take a step in.");
        _game.CurrentPlayer.Inventory.Remove(ItemToUse);
        return;
      }
      else if (ItemToUse.Name.ToLower() == "flashlight" && _game.CurrentRoom.Name == "Sleeping Quarters")
      {
        _game.CurrentRoom.Description = "You stand in the doorway and turn on the flashlight, it's not the brightest but it works well enough.  You shine it around the room as you enter, there's garbage and broken items all around with old metal bed frames scattered about.  There are no windows, no wonder it so dark in here.  There's not much in the room anymore, although you notice that theres a section of furniture with very little dust on them.  And they are clustered up against a section of wall on the south side of the room.";
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