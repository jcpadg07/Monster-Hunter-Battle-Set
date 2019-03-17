using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Hunter_Battle_Set
{
    class Battle_Set
    {
        // Gets or sets the helmet of the set.
        public string Helmet { get; set; }
 
        // Gets or sets the armor of the set.
        public string Armor { get; set; }

        // Gets or sets the weapon of the set.
        public string Weapon { get; set; }

        // Gets or sets the shield of the set.
        public string Shield { get; set; }

        // Returns a string with the items input.
        public override string ToString()
        {
            return Helmet + " and " + Armor + " and " + Weapon + " and " + Shield;
        }

    }
    
}
