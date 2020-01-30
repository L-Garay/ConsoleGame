using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface INPC
  {
    string Name { get; set; }
    List<Item> Inventory { get; set; }
  }
}