using Microsoft.AspNetCore.Mvc;
using RetoFactus.Services;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Caching.Memory;

namespace RetoFactus.Controllers
{
    public class AuthTokenController : Controller
    {
        private readonly AuthService _authService;

        public AuthTokenController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> getToken(string user, string pwd)
        {
            try
            {
                var token = await _authService.GetAccesToken(user, pwd);
                return RedirectToAction("BillsView", "Bills");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el token");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            var tokenR = await _authService.RefreshToken();
            return Ok(tokenR);
        }
    }
}
