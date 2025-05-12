using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTest
{
    internal class ClassPokemon
    {
    }
}    class Pokemon
    {
        public string Name { get; set; }
        public string Typ { get; set; }
        public int Level { get; set; }
        public int KP { get; set; }

        public Pokemon(string name, string typ, int level, int kp)
        {
            Name = name;
            Typ = typ;
            Level = level;
            KP = kp;
        }
    }
