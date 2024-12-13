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

        public SingleClubMember(int id, string name, Club club): base(id, name)
        {
            AssignedClub = club;
        }

        public override void CheckIn(Club club)
        {
            if (club != AssignedClub)
            {
                Console.WriteLine("This is not your club!");
            } else
            {
                Console.WriteLine($"{Name} checked into {club.Name}");
            }

        }
    }
}
