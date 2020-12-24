using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerApp.Web.Infrastructure.Interfaces;

namespace PlayerApp.Web.Constrollers
{
    public class ClubController : Controller
    {
        private readonly IClub repo;
        public ClubController(IClub repo)
        {
            this.repo = repo;
        }

        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await repo.GetClubs();
            return Ok(clubs);
        }
    }
}