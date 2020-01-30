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
      //Main rooms
      Room Courtyard = new Room("Courtyard", "You walk up the driveway and are faced with a large, run down building.  You see the sign 'Name Asylum' and know you're at the right place.  You can see the front door is barred up, but there are no fences around the building.");
      Room Library = new Room("Library", "Library description");
      Room LaundryRoom = new Room("Laundry Room", "Laundry room description");
      Room Kitchen = new Room("Kitchen", "kitchen description");
      Room ManagerOffice = new Room("Manager's Office", "Manager's office room description");
      Room CommonArea = new Room("Common Area", "Common area description");
      Room SleepingQuarters = new Room("Sleeping Quaters", "Sleeping quaters description");
      Room Bathrooms = new Room("Bathrooms", "Bathrooms description");

      //Secondary rooms
      Room EastOutside = new Room("Eastern side of the Asylum", "The outside (east) of the asylum.");
      Room WestOutside = new Room("Western side of the Asylum", "The outside (west) of the asylum");
      Room NorthOutside = new Room("North side of the Asylum", "The backyard (north) of the asylum");
      Room Hallway1 = new Room("First Hallway", "Can go to either the Common area, Kitchen, Bathrooms, or Hallway2");
      Room Hallway2 = new Room("Second Hallway", "can go to either the Laundry room, Manager's office, or back to Hallway1");
      Room SecretPassage = new Room("Secret Passage", "It appears there's a small hole dug into the side of the wall, just big enough for someone to fit through.");

      //Creating NPC(s)
      NPC Brother = new NPC("Brother's Name");

      //Creating items
      Item Shovel = new Item("A Rusty Shovel", "An old rusty metal shovel, leaning up against the side of the building.");
      Item Flashlight = new Item("A Flashlight", "Just your average looking flashlight.");
      Item KitchenKey = new Item("Key to Kitchen", "A silver key that looks like it has some grease or oil on it.");
      Item ManagerKey = new Item("Key to Manager's Office", "A gold key that looks like it's been used often.");

      //Adding items to rooms that need them
      EastOutside.Items.Add(Shovel);
      SleepingQuarters.Items.Add(KitchenKey);
      Kitchen.Items.Add(Flashlight);

      //Adding items to NPC(s) that need them
      Brother.Inventory.Add(ManagerKey);





    }
  }
}