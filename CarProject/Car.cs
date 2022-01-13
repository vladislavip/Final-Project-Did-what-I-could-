using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    [Serializable]
    internal class Car
    {
        private static int counter = 0;
        public Car()

        {   
            this.Id = ++counter;

        }

        static public void SetCounter(int counter)
        {
            Car.counter = counter;
        }

        public int Id { get; set; } 
        public string Name { get; set; }    
        public int ModelId { get; set; }    
        public int Year { get; set; }
        public int BanNo { get; set; }  
        public double EngineVolume { get; set; }
        public string Gearbox { get; set; } 
        public string Color { get; set; }   
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id}.{Name}.{Year}.{BanNo}.{EngineVolume}.{Gearbox}.{Color}.{Price}";
        }


    }
}
