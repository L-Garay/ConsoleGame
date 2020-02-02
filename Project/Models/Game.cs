using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      // Win room
      Room Car = new Room("Car", "You noticed an old toyota pickup parked next to the guard house that looks like it's in decent condition.");

      //Main rooms
      Room Courtyard = new Room("Courtyard", "You walk up the driveway and are faced with a large, run down building.  You see the sign 'Name Asylum' and know you're at the right place.  You can see the front door is barred up, but there are no fences around the building.");
      Room Library = new Room("Library", "Library description");
      Room LaundryRoom = new Room("Laundry Room", "Laundry room description");
      Room Kitchen = new Room("Kitchen", "kitchen description");
      Room ManagerOffice = new Room("Manager's Office", "Manager's office room description");
      Room CommonArea = new Room("Common Area", "Common area description");
      Room SleepingQuarters = new Room("Sleeping Quarters", "Sleeping quarters description");
      Room Bathrooms = new Room("Bathrooms", "Bathrooms description");
      Room ToolShed = new Room("Tool Shed", "An almost collasped shack with some old tools in it.");

      //Secondary rooms
      Room Hallway1 = new Room("First Hallway", "Can go to either the Common area, Kitchen, Bathrooms, or Hallway2");
      Room Hallway2 = new Room("Second Hallway", "can go to either the Laundry room, Manager's office, or back to Hallway1");
      Room SecretPassage = new Room("Secret Passage", "It appears there's a small hole dug into the side of the wall, just big enough for someone to fit through.");
      Room LawnArea1 = new Room("Lawn area #1", "Lawn area leading to the east side of the house.");
      Room LawnArea2 = new Room("Lawn area #2", "Lawn area leading to the west side of the house.");
      Room LawnArea3 = new Room("Lawn area #3", "As you're walking by the house you notice a window slightly ajar.");
      Room LawnArea4 = new Room("Lawn area #4", "As you continue walking by the house, you get to the backyard and see a door.");
      Room LawnArea5 = new Room("Lawn area #5", "You approach the door, the lock appears to be damaged.");
      Room TrapArea1 = new Room("Booby Trapped Kitchen Door", "The door to the kitchen seems cracked open, if you enter it a series of levers and pulleys spring into action swinging an assortment of knives down upon your position.");
      Room TrapArea2 = new Room("Weak wood floor in front of door", "You see a small flicker of light coming from another room, as you approach the floor starts to creek. If you enter, as soon as you cross the doorway the floor gives out and you fall intp a black pit and land on your head.");


      //Creating items
      Item Shovel = new Item("Shovel", "An old rusty metal shovel, leaning up against the side of the building.");
      Item Flashlight = new Item("Flashlight", "Just your average looking flashlight.");
      Item KitchenKey = new Item("Key", "A silver key that looks like it has some grease or oil on it.");
      Item ManagerCard = new Item("Card", "A gold key that looks like it's been used often.");

      //Creating Player, there's a set protagonist
      Player Bob = new Player("Bob");

      //Adding items to rooms that need them
      ToolShed.Items.Add(Shovel);
      SleepingQuarters.Items.Add(KitchenKey);
      Kitchen.Items.Add(Flashlight);
      ManagerOffice.Items.Add(ManagerCard);

      //Adding not locked/trap door exits to the rooms
      Courtyard.Exits.Add("east", LawnArea1);
      Courtyard.Exits.Add("west", LawnArea2);
      LawnArea1.Exits.Add("west", Courtyard);
      LawnArea1.Exits.Add("north", ToolShed);
      ToolShed.Exits.Add("south", LawnArea1);
      LawnArea2.Exits.Add("east", Courtyard);
      LawnArea2.Exits.Add("north", LawnArea3);
      LawnArea3.Exits.Add("south", LawnArea2);
      LawnArea3.Exits.Add("east", Library);
      LawnArea3.Exits.Add("north", LawnArea4);
      LawnArea4.Exits.Add("south", LawnArea3);
      LawnArea4.Exits.Add("east", LawnArea5);
      LawnArea5.Exits.Add("west", LawnArea4);
      LawnArea5.Exits.Add("south", LaundryRoom);
      LaundryRoom.Exits.Add("east", Hallway2);
      Hallway2.Exits.Add("west", LaundryRoom);
      Hallway2.Exits.Add("south", Hallway1);
      Hallway1.Exits.Add("north", Hallway2);
      Hallway1.Exits.Add("east", Bathrooms);
      Hallway1.Exits.Add("south", CommonArea);
      Bathrooms.Exits.Add("west", Hallway1);
      Bathrooms.Exits.Add("south", SleepingQuarters);
      SleepingQuarters.Exits.Add("north", Bathrooms);
      CommonArea.Exits.Add("north", Hallway1);
      CommonArea.Exits.Add("west", Library);
      Library.Exits.Add("east", CommonArea);
      Library.Exits.Add("west", LawnArea3);
      Kitchen.Exits.Add("north", LaundryRoom);
      ManagerOffice.Exits.Add("south", SleepingQuarters);

      //Adding locked/hidden doors to rooms
      LaundryRoom.LockedExits.Add(KitchenKey, new KeyValuePair<string, IRoom>("south", Kitchen));
      Hallway2.LockedExits.Add(Shovel, new KeyValuePair<string, IRoom>("east", ManagerOffice));
      ManagerOffice.LockedExits.Add(ManagerCard, new KeyValuePair<string, IRoom>("west", Hallway2));
      SleepingQuarters.LockedExits.Add(Flashlight, new KeyValuePair<string, IRoom>("south", ManagerOffice));
      Courtyard.LockedExits.Add(ManagerCard, new KeyValuePair<string, IRoom>("south", Car));

      //Adding trap doors to rooms
      Hallway1.Exits.Add("west", TrapArea1);
      TrapArea1.Exits.Add("east", Hallway1);
      CommonArea.Exits.Add("east", TrapArea2);
      TrapArea2.Exits.Add("west", CommonArea);

      //Starting room when game begins
      CurrentRoom = Courtyard;

      //Setting current player to main character
      CurrentPlayer = Bob;


    }

    public Game()
    {
      Setup();
    }

  }
}