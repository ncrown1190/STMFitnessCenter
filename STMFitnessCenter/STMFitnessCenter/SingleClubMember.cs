using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMFitnessCenter
{
    public class SingleClubMember : Member
    {
        public Club AssignedClub { get; set; }

        public SingleClubMember(string name, Club assignedClub): base(name)
        {
            AssignedClub = assignedClub;
        }

        public override void CheckIn(Club club)
        {
            if (club.Name != AssignedClub.Name)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception($"Cannot check in. {Name} is assigned to {AssignedClub.Name}");
            } else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"{Name} checked into {club.Name}");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
