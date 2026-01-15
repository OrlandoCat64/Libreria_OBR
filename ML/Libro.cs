using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public DateTime AñoPublicacion { get; set; }
        public int IdAutor { get; set; }
        public int IdEditorial { get; set; }

        //Propiedad de navegacion 
        public string NombreAutor { get; set; }
        public string NombreEditorial { get; set; }
    }
}
