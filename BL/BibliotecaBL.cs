using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BibliotecaBL
    {
        //Agregar Libro 
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    int rowsAffected = context.AddLibro(
                        libro.Titulo,
                        libro.AñoPublicacion,
                        libro.IdAutor,
                        libro.IdEditorial
                    );

                    if (rowsAffected > 0)
                        result.Correct = true;
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar el libro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //Consultar lirbo por autor 
        public static ML.Result GetByLibroPorAutor(int IdAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    var registros = context.LibroPorAutor(IdAutor).ToList();

                    result.Objects = new List<object>();

                    if (registros.Count > 0)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = registro.IdLibro;
                            libro.Titulo = registro.Titulo;
                            libro.AñoPublicacion = registro.AñoPublicacion ?? DateTime.MinValue;
                            libro.IdAutor = registro.IdAutor;
                            libro.IdEditorial = registro.IdEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay libros para este autor";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //Obetener el por el titulo del libro 

        public static ML.Result GetByTituloLibro(string Titulo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    var registros = context.LibrosPorTitulo(Titulo).ToList();

                    result.Objects = new List<object>();

                    if (registros.Count > 0)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = registro.IdLibro;
                            libro.Titulo = registro.Titulo;
                            libro.AñoPublicacion = registro.AñoPublicacion ?? DateTime.MinValue;
                            libro.IdAutor = registro.IdAutor;
                            libro.IdEditorial = registro.IdEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron libros con ese título";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //Obtener por fecha de libro

        public static ML.Result GetByFechaLibro(DateTime AñoPublicacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    var registros = context.LibrosPorFecha(AñoPublicacion).ToList();

                    result.Objects = new List<object>();

                    if (registros.Count > 0)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = registro.IdLibro;
                            libro.Titulo = registro.Titulo;
                            libro.AñoPublicacion = registro.AñoPublicacion ?? DateTime.MinValue;
                            libro.IdAutor = registro.IdAutor;
                            libro.IdEditorial = registro.IdEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay libros en esa fecha";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //Consultar por fecha y autor 
        public static ML.Result GetByFechaYAutor(int IdAutor, DateTime AñoPublicacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    var registros = context.LibrosPorFechaYHora(IdAutor, AñoPublicacion).ToList();

                    result.Objects = new List<object>();

                    if (registros.Count > 0)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = registro.IdLibro;
                            libro.Titulo = registro.Titulo;
                            libro.AñoPublicacion = registro.AñoPublicacion ?? DateTime.MinValue;
                            libro.IdAutor = registro.IdAutor;
                            libro.IdEditorial = registro.IdEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay libros para ese autor en esa fecha";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //Borrar por autor 
        public static ML.Result DeleteByAutor(int IdAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    int rowsAffected = context.DeleteLibros(IdAutor);

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron libros para ese autor";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //Borrar por editorial 
        public static ML.Result DeleteByEditorial(int IdEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    int rowsAffected = context.BorrarLibroPorEditorial(IdEditorial);

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron libros para esa editorial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaDBEntities context = new DL.BibliotecaDBEntities())
                {
                    var registros = context.GetAllLibros().ToList();

                    result.Objects = new List<object>();

                    if (registros.Count > 0)
                    {
                        foreach (var registro in registros)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = registro.IdLibro;
                            libro.Titulo = registro.Titulo;
                            libro.AñoPublicacion = registro.AñoPublicacion ?? DateTime.MinValue;
                            libro.NombreAutor = registro.NombreAutor;     
                            libro.NombreEditorial = registro.NombreEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay libros registrados";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


    }

}
