using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Views.PlayerView
{
    public class PlayerViewModel
    {
        public PlayerViewModel(Player player)
        {
            Id = player.Id;
            FirstName = player.FirstName;
            LastName = player.LastName;
            FieldPosition = player.FieldPosition;
            IsHidden = player.IsHidden;

            ManagerName = player.Manager.Name;
            ClubName = player.Club.Name;
            ManagerId = player.ManagerId;
            ClubId = player.ClubId;

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FieldPosition { get; set; }
        public bool IsHidden { get; set; }
        public string ManagerName { get; set; }
        public string ClubName { get; set; }
        public int ManagerId { get; set; }
        public int ClubId { get; set; }


    }
}