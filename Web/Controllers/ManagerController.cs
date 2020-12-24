using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerApp.Web.Infrastructure.Interfaces;

namespace PlayerApp.Web.Constrollers
{
    public class ManagerController : Controller
    {
        private readonly IManager repo;
        public ManagerController(IManager repo)
        {
            this.repo = repo;
        }

        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetManagers()
        {
            var managers = await repo.GetManagers();
            return Ok(managers);
        }
    }
}