using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayerApp.Web.Data;
using PlayerApp.Web.Entities;
using PlayerApp.Web.Infrastructure.Interfaces;

namespace PlayerApp.Web.Infrastructure.Repositories
{
    public class ManagerRepo : IManager
    {
        private readonly AppDbContext context;

        public ManagerRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Manager>> GetManagers()
        {
            return await context.Managers.ToListAsync();
        }
    }
}