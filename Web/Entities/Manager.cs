using System;
using System.Collections.Generic;

namespace PlayerApp.Web.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();

        internal Manager(string name)
        {
            SetName(name);
        }

        public Manager SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), Constants.ManagerNameIsNullException);

            Name = name;
            return this;
        }
    }
}