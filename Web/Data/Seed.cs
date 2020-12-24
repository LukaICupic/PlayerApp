using PlayerApp.Web.Entities;

namespace PlayerApp.Web.Data
{
    public class Seed
    {
        static Manager manager = new Manager("Darko");
        static Club club = new Club("Barcelona");
        public static Manager[] ManagerSeed = new Manager[]{
            new Manager("Marko"),
            new Manager("Ana")
        };

        public static Club[] ClubSeed = new Club[]{
            new Club("Dinamo"),
            new Club("Hajduk")
        };

        public static Player[] PlayerSeed = new Player[]{
            new Player("Luka","Lulić","Goalkeeper"){Manager = manager, ManagerId = manager.Id, Club = club, ClubId = club.Id},
            new Player("Marko","Lulić","Left wing"){Manager = manager, ManagerId = manager.Id, Club = club, ClubId = club.Id}

        };
    }
}