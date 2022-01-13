using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    [Serializable]
    internal class Model
    {

        private static int counter = 0;
        public Model()

        {
            
            this.Id = ++counter;

        }

        static public void SetCounter(int counter)
        {
            Model.counter = counter;
        }
        public int Id { get; set; }  
        public string Name { get; set; }    
        public int MarkaId { get; set; }

        public override string ToString()
        {
            return $"{Id}.{Name}";
        }

    }
}
