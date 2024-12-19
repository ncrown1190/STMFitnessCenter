using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMFitnessCenter
{
    public class MultiClubMember : Member
    {
        public int MembershipPoints { get; set; }
        public MultiClubMember(string name): base(name) 
        {
            MembershipPoints = 0;
        }

        public override void CheckIn(Club club)
        {
            MembershipPoints += 10;
            Console.WriteLine($"\nMultiClub Member {Name} is Checked in at {club.Name}. Points: {MembershipPoints}");
        }
        public int GetPoints()
        {
            return MembershipPoints;
        }
    }
}
