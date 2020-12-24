using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Views.PlayerView
{
    public class PlayerGetVM
    {
        public PlayerGetVM(Player player)
        {
            Id = player.Id;
            FirstName = player.FirstName;
            LastName = player.LastName;
            FieldPosition = player.FieldPosition;
            ManagerName = player.Manager.Name;
            ClubName = player.Club.Name;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FieldPosition { get; set; }
        public string ManagerName { get; set; }
        public string ClubName { get; set; }
    }
}