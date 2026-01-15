using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiRest.Controllers
{

    [RoutePrefix("api/libro")]
    public class LibroController : ApiController
    {
        // POST: api/libro/add
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add([FromBody] Libro libro)
        {
            Result result = BibliotecaBL.Add(libro);
            if (result.Correct)
                return Ok("Libro agregado correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }

        // GET: api/libro/autor/{idAutor}
        [HttpGet]
        [Route("autor/{idAutor}")]
        public IHttpActionResult GetByAutor(int idAutor)
        {
            Result result = BibliotecaBL.GetByLibroPorAutor(idAutor);
            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }

        // GET: api/libro/titulo/{titulo}
        [HttpGet]
        [Route("titulo/{titulo}")]
        public IHttpActionResult GetByTitulo(string titulo)
        {
            Result result = BibliotecaBL.GetByTituloLibro(titulo);
            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }

        // GET: api/libro/fecha?anio=2023-01-01
        [HttpGet]
        [Route("fecha")]
        public IHttpActionResult GetByFecha([FromUri] DateTime año)
        {
            Result result = BibliotecaBL.GetByFechaLibro(año);
            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }

        // GET: api/libro/fechaYautor?idAutor=1&anio=2023-01-01
        [HttpGet]
        [Route("fechaYautor")]
        public IHttpActionResult GetByFechaYAutor([FromUri] int idAutor, [FromUri] DateTime anio)
        {
            Result result = BibliotecaBL.GetByFechaYAutor(idAutor, anio);
            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }



        // DELETE: api/libro/autor/{idAutor}
        [System.Web.Http.HttpDelete]
        [Route("delete/autor/{idAutor}")]
        public IHttpActionResult DeleteByAutor(int idAutor)
        {
            Result result = BibliotecaBL.DeleteByAutor(idAutor);
            if (result.Correct)
                return Ok("Libros borrados correctamente");
            else
                return NotFound();
        }

        // DELETE: api/libro/editorial/{idEditorial}
        [System.Web.Http.HttpDelete]
        [Route("delete/editorial/{idEditorial}")]
        public IHttpActionResult DeleteByEditorial(int idEditorial)
        {
            Result result = BibliotecaBL.DeleteByEditorial(idEditorial);
            if (result.Correct)
                return Ok("Libros borrados correctamente");
            else
                return NotFound();
        }
    }
}
