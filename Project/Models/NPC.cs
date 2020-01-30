using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class NPC : INPC
  {
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }
    public NPC(string name)
    {
      Name = name;
    }
  }
}