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
        public MultiClubMember(int id, string name): base(id, name) 
        {
            MembershipPoints = 0;
        }

        public override void CheckIn(Club club)
        {
            MembershipPoints += 10;
        }
    }
}
