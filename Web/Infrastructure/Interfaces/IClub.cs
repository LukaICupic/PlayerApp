using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Infrastructure.Interfaces
{
    public interface IClub
    {
        Task<IEnumerable<Club>> GetClubs();
    }
}