using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerApp.Web.Data;
using PlayerApp.Web.Entities;
using PlayerApp.Web.Infrastructure.Interfaces;
using PlayerApp.Web.Views.PlayerView;

namespace PlayerApp.Web.Constrollers
{
    public class PlayerController : Controller
    {
        private readonly IPlayer repo;
        private readonly AppDbContext context;

        public PlayerController(IPlayer repo, AppDbContext context)
        {
            this.repo = repo;
            this.context = context;
        }

        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await repo.GetPlayers();
            List<PlayerGetVM> playerList = new List<PlayerGetVM>();

            foreach (var p in players)
            {
                PlayerGetVM playerVM = new PlayerGetVM(p);
                playerList.Add(playerVM);
            }

            return Ok(playerList);
        }

        [HttpGet("api/[controller]/{Id}")]
        public async Task<IActionResult> GetPlayer(int Id)
        {
            var player = await repo.GetPlayer(Id);
            var result = new PlayerViewModel(player);

            return Ok(result);
        }

        [HttpPost("api/[controller]")]
        public async Task<IActionResult> AddPlayer([FromBody] PlayerCreateVM playerCVM)
        {
            var newPlayer = new Player(playerCVM.FirstName, playerCVM.LastName, playerCVM.FieldPosition);
            newPlayer.IsHidden = false;

            var manager = context.Managers.SingleOrDefault(m => m.Id == playerCVM.ManagerId);
            if (manager == null)
            {
                throw new Exception($"Manager with the given Id {playerCVM.ManagerId} could not be found");
            }

            var club = context.Clubs.SingleOrDefault(c => c.Id == playerCVM.ClubId);
            if (club == null)
            {
                throw new Exception($"Club with the given Id {playerCVM.ClubId} could not be found");
            }

            newPlayer.Manager = manager;
            newPlayer.Club = club;

            await repo.AddPlayer(newPlayer);
            return Ok(newPlayer);
        }

        [HttpPut("api/[controller]/{Id}")]
        public async Task<IActionResult> UpdatePlayer(int Id, [FromBody] PlayerEditVM playerEVM)
        {
            var player = new Player(playerEVM.FirstName, playerEVM.LastName, playerEVM.FieldPosition);

            player.Id = Id;
            player.FirstName = playerEVM.FirstName;
            player.LastName = playerEVM.LastName;
            player.FieldPosition = playerEVM.FieldPosition;
            player.ManagerId = playerEVM.ManagerId;
            player.ClubId = playerEVM.ClubId;

            await repo.EditPlayer(player);

            return Ok(player);
        }

        [HttpDelete("api/[controller]/{Id}")]
        public async Task<IActionResult> RemovePlayer(int Id)
        {
            await repo.DeletePlayer(Id);

            return RedirectToAction("GetPlayers");
        }
    }
}