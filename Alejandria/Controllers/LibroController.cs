using Alejandria.Interfaces.IServices;
using Alejandria.Models;
using Alejandria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Alejandria.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorservices;  
        public LibroController(ILibroService libroService, IAutorService autorservices)
        {
            _libroService = libroService;
            _autorservices = autorservices;
        }
        public async Task<IActionResult> Lista(ListarBuscarFormLibroViewModel formularioViewModel)
        {
            try
            {
                IQueryable<Libro> libros = await _libroService.Listar();
                formularioViewModel.Libros = libros;
                return View(formularioViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpGet]
        public async  Task<IActionResult> Formulario(ListarBuscarFormLibroViewModel formularioViewModel)
        {
            try
            {
                IQueryable<Autor> autores = await _autorservices.Listar();
                formularioViewModel.Autores = autores;
                return View(formularioViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        public IActionResult Crear_Actualizar(Libro libro)    
        {
            try
            {
                if (libro.Id == 0)
                {
                    _libroService.Crear(libro);
                }
                else
                {
                    _libroService.Actualizar(libro);
                }
                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        public async Task<IActionResult> Eliminar(int Id)
        {
            try
            {
                await _libroService.Eliminar(Id);
                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        public async Task<IActionResult> BuscarPorNombre(ListarBuscarFormLibroViewModel formularioViewModel)
        {
            try
            {
                IQueryable<Libro> libros = await _libroService.BuscarPorNombre(formularioViewModel.NombreBuscar!);
                formularioViewModel.Libros = libros;
                return View("Lista", formularioViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
