using MrWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MrWebAPI.Controllers
{
    public class PublicacionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Publicacion> Get()
        {
            using (var context = new PublicContext())
            {
                return context.Publicaciones.ToList();
            }
        }

        [HttpGet]
        public Publicacion Get(int id)
        {
            using (var context = new PublicContext())
            {
                return context.Publicaciones.FirstOrDefault(x => x.Id == id);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var context = new PublicContext())
            {
                context.Publicaciones.Add(publicacion);
                context.SaveChanges();
                return Ok(publicacion);
            }
        }

        [HttpPut]
        public Publicacion Put(Publicacion publicacion)
        {
            using (var context = new PublicContext())
            {
                var publicacionActualizar = context.Publicaciones.FirstOrDefault(x => x.Id == publicacion.Id);
                publicacionActualizar.Descripcion = publicacion.Descripcion;
                publicacionActualizar.EsPrivada = publicacion.EsPrivada;
                context.SaveChanges();
                return publicacion;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new PublicContext())
            {
                var publicacionEliminar = context.Publicaciones.FirstOrDefault(x => x.Id == id);
                context.Publicaciones.Remove(publicacionEliminar);
                context.SaveChanges();
                return true;
            }
        }
    }
}
