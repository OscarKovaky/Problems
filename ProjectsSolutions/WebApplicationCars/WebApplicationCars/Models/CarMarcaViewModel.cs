using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCars.Models
{
    public class CarMarcaViewModel
    {

        public List<Car> Cars { get; set; }
        public SelectList Marca { get; set; }
        public string CarMarca { get; set; }
        public string SearchString { get; set; }


    }
}
