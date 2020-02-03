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
      // Winning Rooms
      Room Car = new Room("Car", "You noticed an old toyota pickup parked next to the guard house that looks like it's in decent condition. It might even be your brother's...");
      Room WinRoom = new Room("Win Room", "You have escaped the asylum. Congratulations.");

      //Main rooms
      Room Courtyard = new Room("Courtyard", "You walk up the driveway, after you parked your car next to another pickup. And you are faced with a large, run down building.  You see the sign 'Name Asylum' and know you're at the right place. This is the place your brother came 2 years ago in search of the truth.  You haven't heard from him since that day, so now you've come yourself to try to find the truth of what happened. You must find your brother, and find evidence of what has been going on. As you approach the front of the building, can see the front door is barred up, but there are no fences around the sides.");
      Room Library = new Room("Library", "As you enter the library you look around the room.  There's shelves knocked over and books and pages strewn across the room. On one of the tables you notice a collection of notes and illustrations.  Upon further inspection, it look like it could be your brothers handwriting!  It's hard to make out what they say, and the images are disturbing; but it's a sign that he was here.");
      Room LaundryRoom = new Room("Laundry Room", "You enter what appears to be a laundry room.  However it would be mistaken if you couldn't tell.  On all the clothing hangers are the corpses of animals; you dare not look inside the old machines. The stench is enough to keep you moving quickly. There are only two doors and one looks like it leads out into a hallway.");
      Room Kitchen = new Room("Kitchen", "As you slowly enter the kitchen, a loud noice suddenly scares the hell out of you, but you quickly realize it was just a rat who knocked over a pan.  Looking around the room it appears as though it's been in use recently; although whoever it was wasn't making any 5 star meals...you can see half cut open roadkill on the counters with what looks like all expired products laid out next to it.  There's got to be something of value in here though.");
      Room ManagerOffice = new Room("Manager's Office", "The first thing you notice as you enter the manager's office is the giant wall of screens, some have static but others are live feeds of cameras around the building...how could they still be working, maybe there's important video evidence on there.  As you start to approach the monitors, the chair swivels around and sitting in it is this horrible looking creature with rotting skin and tattered clothing. It tries to make sounds but they are indescernable; but something about this creature does strike you.  It is wearing a silver cross around it's neck, just like the one you are wearing; just like the one your brother bought for both of you when your mother died. However you don't have much time to think, as the creature lunges out of the chair at you!");
      Room CommonArea = new Room("Common Area", "As you step out into the common area you are overwhelmed with the smell of death.  And you quickly realize why; there is a giant pile of rotting bodies piled behind the receptions desk.  The giant ornate chandellier fell long ago, and this room like many others is in shambles.  There are a couple of different ways to proceed, but be careful.");
      Room SleepingQuarters = new Room("Sleeping Quarters", "You approach cautiously, and peer into the pitch darkness.  Of all the rooms this is th only one with no windows.  It's too dark to see anything.  Maybe there's a light switch somewhere.");
      Room Bathrooms = new Room("Bathrooms", "You could smell the bathrooms from down the hallway, obviously plumbing hasn't been functional for a while, yet there is quite the stench; as if still being used.  It might be best to move along quickly, as to avoid getting sick from something.  What could be in that pitch black room? ");
      Room ToolShed = new Room("Tool Shed", "An almost collasped shack with some old tools in it.");

      //Secondary rooms
      Room Hallway1 = new Room("First Hallway", "You step into a long hallway with doors in all directions.");
      Room Hallway2 = new Room("Second Hallway", "You step into a long hallway with numerous options.");
      Room SecretPassage = new Room("Secret Passage", "It appears there's a small hole dug into the side of the wall, just big enough for someone to fit through.");
      Room LawnArea1 = new Room("Lawn area #1", "You walk to the SE edge of the building and look around the corner. One way, you see some sort of shed further down the side of the building. The other takes you back to the Courtyard.");
      Room LawnArea2 = new Room("Lawn area #2", "You walk to the SW edge of the building and look around the corner.");
      Room LawnArea3 = new Room("Lawn area #3", "As you're walking North by the house you notice a window slightly ajar. It looks like you may be able to reach it.");
      Room LawnArea4 = new Room("Lawn area #4", "As you continue walking by the house, you get to the NW corner of the house and peer into the backyard.  There's nothing but woods.  As you're about to turn around, you see an door open further along the back of the house.");
      Room LawnArea5 = new Room("Lawn area #5", "As you approach the door, it slams shut.  However, the lock appears to be damaged.");
      Room TrapArea1 = new Room("Booby Trapped Kitchen Door", "The door to the kitchen seems cracked open, however something doesn't seem quite right.  As you begin to touch the door, you can feel some sort of tension on it. ");
      Room DeathArea1 = new Room("Death #1", "You decide it must be in your head, and you open the door with your full force and take a step through.  At first nothing happens and you look around; but then suddenly you hear a snap, and out of the corner of your eye you see objects comming towards you. Before you can react, multiple knives that were hanging and being pulled back by a series of levers connected to the door, come swinging down and impale you all over.");
      Room TrapArea2 = new Room("Weak wood floor in front of door", "You see a small flicker of light coming from another room, as if someone with a candle walked by the door.  As you quickly approach the door, the floor starts to creek. You look down and can see many missing wooden floor pieces, who know's what is underneath this place; but what was that light?");
      Room DeathArea2 = new Room("Death #2", "You try to carefully pick your path along to the door, and as you hop from one section to the next, the planks seem to be holding up.  You get to the door, and reach for the handle, but as soon as you stand still for more than a second, the planks beneath you start to give out.  You hold on to the handle as the planks fall away, but the handle is old and easily snaps off, you fall down into the pitch black pit below.");


      //Creating items
      Item Shovel = new Item("Shovel", "An old rusty metal shovel, leaning up against the side of the building.");
      Item Flashlight = new Item("Flashlight", "Just your average looking flashlight.");
      Item KitchenKey = new Item("Kitchenkey", "A silver key that looks like it has some grease or oil on it.");
      Item ManagerCard = new Item("Card", "A keychain with some sort key and card on it.");
      Item CarKey = new Item("Carkey", "The key to that old pickup out front.");

      //Creating Player, there's a set protagonist
      Player Bob = new Player("Bob");

      //Adding items to rooms that need them
      ToolShed.Items.Add(Shovel);
      SleepingQuarters.Items.Add(KitchenKey);
      Kitchen.Items.Add(Flashlight);
      ManagerOffice.Items.Add(ManagerCard);
      ManagerOffice.Items.Add(CarKey);

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
      Courtyard.Exits.Add("south", Car);

      //Adding locked/hidden doors to rooms
      LaundryRoom.LockedExits.Add(KitchenKey, new KeyValuePair<string, IRoom>("south", Kitchen));
      Hallway2.LockedExits.Add(Shovel, new KeyValuePair<string, IRoom>("east", ManagerOffice));
      ManagerOffice.LockedExits.Add(ManagerCard, new KeyValuePair<string, IRoom>("west", Hallway2));
      SleepingQuarters.LockedExits.Add(Flashlight, new KeyValuePair<string, IRoom>("south", ManagerOffice));
      Car.LockedExits.Add(CarKey, new KeyValuePair<string, IRoom>("south", WinRoom));

      //Adding trap doors to rooms
      Hallway1.Exits.Add("west", TrapArea1);
      TrapArea1.Exits.Add("east", Hallway1);
      TrapArea1.Exits.Add("west", DeathArea1);
      CommonArea.Exits.Add("east", TrapArea2);
      TrapArea2.Exits.Add("west", CommonArea);
      TrapArea2.Exits.Add("east", DeathArea2);

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