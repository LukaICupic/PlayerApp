namespace PlayerApp.Web.Views.PlayerView
{
    public class PlayerEditVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FieldPosition { get; set; }
        public int ManagerId { get; set; }
        public int ClubId { get; set; }
    }
}