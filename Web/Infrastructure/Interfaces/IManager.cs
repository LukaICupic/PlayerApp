using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Infrastructure.Interfaces
{
    public interface IManager
    {
        Task<IEnumerable<Manager>> GetManagers();
    }
}