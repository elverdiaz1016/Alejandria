using Alejandria.Interfaces.IServices;
using Alejandria.Models;
using Alejandria.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Alejandria.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }
        public  async Task<IActionResult> Lista(ListarBuscarAutorViewModel buscarListarViewModel)
        {
            try
            {
                IQueryable<Autor> usuarios = await _autorService.Listar();
                buscarListarViewModel.Autores = usuarios;
                return View(buscarListarViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { mensajeError = ex.Message });
            }
        }
        public IActionResult Formulario(Autor autor)
        {
            try
            {
                return View(autor);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { mensajeError = ex.Message });
            }
        }


        [HttpPost]
        public  IActionResult Crear_Actualizar(Autor autor)
        {
            try
            {
                if (autor.Id == 0)
                {
                    _autorService.Crear(autor);
                }
                else
                {
                    _autorService.Actualizar(autor);
                }
                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { mensajeError = ex.Message });
            }
        }       
        public async Task<IActionResult> Eliminar(int Id)
        {
            try
            {
                var autor = await _autorService.Eliminar(Id);
                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Lista");
            }
        }
        public async Task<ActionResult> BuscarPorNombre(ListarBuscarAutorViewModel buscarListarViewModel)
        {
            try
            {
                throw new Exception("Hola Arialdo");
                IQueryable<Autor> autores = await _autorService.BuscarPorNombre(buscarListarViewModel.NombreBuscar!);
                buscarListarViewModel.Autores = autores;
                return View("Lista", buscarListarViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error", new { mensajeError = ex.Message });
            }
        }
    }
}

