using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Entities
{
    public class Person
    {
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
        public int NmbrOfChildren { get; set; }
        public bool IsAlive { get; set; }
        public Person()
        {
            IsAlive = true;
        }
    }
}
