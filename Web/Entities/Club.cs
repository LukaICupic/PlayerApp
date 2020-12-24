using System;
using System.Collections.Generic;

namespace PlayerApp.Web.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();

        internal Club(string name)
        {
            SetName(name);
        }

        public Club SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), Constants.ClubNameIsNullException);

            Name = name;
            return this;
        }
    }
}