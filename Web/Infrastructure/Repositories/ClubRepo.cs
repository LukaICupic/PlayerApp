using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayerApp.Web.Data;
using PlayerApp.Web.Entities;
using PlayerApp.Web.Infrastructure.Interfaces;

namespace PlayerApp.Web.Infrastructure.Repositories
{
    public class ClubRepo : IClub
    {
        private readonly AppDbContext context;

        public ClubRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Club>> GetClubs()
        {
            return await context.Clubs.ToListAsync();
        }
    }
}