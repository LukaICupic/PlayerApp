using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Infrastructure.Interfaces
{
    public interface IPlayer
    {
        Task<Player> GetPlayer(int Id);
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> AddPlayer(Player player);
        Task<Player> EditPlayer(Player player);
        Task<Player> DeletePlayer(int Id);
    }
}