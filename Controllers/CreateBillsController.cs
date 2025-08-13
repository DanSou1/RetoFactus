using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetoFactus.Models;
using RetoFactus.Models.ViewModels;
using RetoFactus.Services;

namespace RetoFactus.Controllers
{
    public class CreateBillsController : Controller
    {
        private readonly RangeIdService _rangeIdService;
        private readonly MunicipalitiesService _municipalitiesService;
        public CreateBillsController(RangeIdService billsService, MunicipalitiesService municipalitiesService)
        {
            _rangeIdService = billsService;
            _municipalitiesService = municipalitiesService;
        }
        [HttpGet]
        public async Task<IActionResult> NewBill()
        {
            var getRangeId = await _rangeIdService.RangeId();
            var getMunicipalitie = await _municipalitiesService.Municipalities();

            if (getRangeId == null && getMunicipalitie == null)  return View("Error", "No se pudo obtener el rango de ID y el municipio.");

            var viewModel = new CreateBillViewModel
            {
                detailBillModel = new DetailBillModel(),
                numberRangeResponse = getRangeId,
                municipalitiesModel = getMunicipalitie
            };
            return View("~/Views/Bills/NewBill.cshtml", viewModel);
        }

        [HttpGet]
        public async Task<RootNumberRange> RangeId()
        {
            try
            {
                return await _rangeIdService.RangeId();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el rango de ID.", ex);
                return null;
            }
        }
        [HttpGet]
        public async Task<MunicipalitiesModel> Municipalities()
        {
            try
            {
                return await _municipalitiesService.Municipalities();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los municipios.", ex);
                return null;
            }
        }
        
    }
}
