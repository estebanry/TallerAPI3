using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MrWebAPI.Models
{
        [Table("Publicacion")]
        public class Publicacion
        {
            [Key]
            public int Id { get; set; }
            [MaxLength(60)]
            [Required]
            public string Usuario { get; set; }
            [MaxLength(200)]    
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public int MeGusta { get; set; }
            public int MeDisgusta { get; set; }
            public int VecesCompartido { get; set; }
            public bool EsPrivada { get; set; }

            public override string ToString()
            {
                return $"Id:{Id} - Usuario:{Usuario} - MeGusta:{MeGusta} - MeDisgusta:{MeDisgusta} - VecesCompartido:{VecesCompartido}";
            }

    }


}