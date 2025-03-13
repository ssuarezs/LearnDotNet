using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingLooping;
internal class Pet
{
    public Guid ID { get; set; }
    public PetSpecies Specie { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; } = "";
    public string Personality { get; set; } = "";
    public string Nickname { get; set; } = "";
}

internal enum PetSpecies {
    Cat,
    Dog
}
