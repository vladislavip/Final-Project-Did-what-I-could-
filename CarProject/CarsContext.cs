using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    [Serializable]
    internal class CarsContext
    {
        public GenericStore<Car> CarsGroup { get; set; }
        public GenericStore<Marka> MarkasGroup { get; set; }
        public GenericStore<Model> ModelsGroup { get; set; }
    }
}
