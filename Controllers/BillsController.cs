using Microsoft.AspNetCore.Mvc;
using RetoFactus.Models;
using RetoFactus.Services;

namespace RetoFactus.Controllers
{
    public class BillsController : Controller
    {
        private readonly GetBillsService _getBillsService;

        public BillsController(GetBillsService getBillsService)
        {
            _getBillsService = getBillsService;
        }
        public async Task<IActionResult> BillsView()
        {
            var bills = await GetAllBills();
            if (bills == null)
            {
                ViewBag.Mensaje = "No se pudieron leer las facturas.";
                return View();
            }
            else
            {
                return View("BillsView", bills);
            }
        }
        [HttpGet]
        public async Task <BillsResponse> GetAllBills()
        {
            try
            {
                return await _getBillsService.GetAllBills();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la factura.", ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return null;
            }
        }
    }
}
