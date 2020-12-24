using System;

namespace PlayerApp.Web.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FieldPosition { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public bool IsHidden { get; set; }

        internal Player(string firstName, string lastName, string fieldPosition)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetFieldPositionName(fieldPosition);
        }

        public Player SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName), Constants.PlayerNameIsNullException);

            FirstName = firstName;
            return this;
        }
        public Player SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException(nameof(lastName), Constants.PlayerNameIsNullException);

            LastName = lastName;
            return this;
        }

        public Player SetFieldPositionName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), Constants.FieldNameIsNullException);

            FieldPosition = name;
            return this;
        }

        //define the method in the controller after a manager was selected
        //and check if it's an existing one
        public Player AddManager(Manager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager), Constants.ManagerIsNullException);

            Manager = manager;
            ManagerId = manager.Id;

            return this;
        }

        public Player AddClub(Club club)
        {
            if (club == null)
                throw new ArgumentNullException(nameof(club), Constants.ClubIsNullException);

            Club = club;
            ClubId = club.Id;

            return this;
        }
    }


}