using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MrWebAPI.Models
{
    public class PublicContext : DbContext
    {
        public PublicContext() : base("PublicConexion")
        {

        }

        public DbSet<Publicacion> Publicaciones { get; set; }

    }
}