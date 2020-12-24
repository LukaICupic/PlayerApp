using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayerApp.Web.Data;
using PlayerApp.Web.Entities;
using PlayerApp.Web.Infrastructure.Interfaces;

namespace PlayerApp.Web.Infrastructure.Repositories
{
    public class PlayerRepo : IPlayer
    {
        private readonly AppDbContext context;

        public PlayerRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            if (player == null)
                throw new Exception(Constants.PlayerIsNullException);

            context.Players.Add(player);
            await context.SaveChangesAsync();

            return player;
        }

        public async Task<Player> DeletePlayer(int Id)
        {
            var player = await context.Players.SingleOrDefaultAsync(i => i.Id == Id);

            if (player == null)
                throw new Exception(Constants.PlayerNotFound);

            player.IsHidden = true;
            await context.SaveChangesAsync();

            return player;
        }

        public async Task<Player> EditPlayer(Player player)
        {
            var newPlayer = await context.Players.SingleAsync(i => i.Id == player.Id);
            var manager = await context.Managers.SingleAsync(i => i.Id == player.ManagerId);
            var club = await context.Clubs.SingleAsync(i => i.Id == player.ClubId);

            newPlayer
            .SetFirstName(player.FirstName)
            .SetLastName(player.LastName)
            .AddManager(manager)
            .AddClub(club);

            await context.SaveChangesAsync();
            return newPlayer;

        }

        public async Task<Player> GetPlayer(int Id)
        {
            var player = await context.Players
            .Include(r => r.Manager)
            .Include(r => r.Club)
            .SingleOrDefaultAsync(i => i.Id == Id && !i.IsHidden);

            if (player == null)
                throw new Exception(Constants.PlayerNotFound);

            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await context.Players
            .Where(i => !i.IsHidden)
            .Include(r => r.Manager)
            .Include(r => r.Club)
            .ToListAsync();
        }
    }
}