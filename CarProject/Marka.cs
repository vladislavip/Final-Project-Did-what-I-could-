using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    [Serializable]
    internal class Marka
    {

        private static int counter = 0;
        public Marka()

        {
           
            this.Id = ++counter;

        }

        static public void SetCounter(int counter)
        {
            Marka.counter = counter;
        }
        public int Id { get; set; }

        public string Name { get; set; }


        public override string ToString()
        {
            return $"{Id}.{Name}";
        }

    }
}
