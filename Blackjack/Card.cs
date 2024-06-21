using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        public string Name { get; set; }
        public string Suite { get; set; }
        public int Value { get; set; }
        
        public Card(string name, string suite, int value)
        {
            this.Name = name;
            this.Suite = suite;
            this.Value = value;
        }
    }
}
