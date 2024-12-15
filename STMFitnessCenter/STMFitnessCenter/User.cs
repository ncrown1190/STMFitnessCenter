using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace STMFitnessCenter
{
    public class User
    {
        List<Member> members = new List<Member>();

        public static List<Club> clubList = new()
        {
            new Club("STM Fitness Center", "1122 Mich Ave, Canton, Michigan"),
            new Club( "Detroit Club", "1122 Gratiot Ave, Detroit, Michigan"),
            new Club( "Muscle Hustle", "333 Airport Blvd, Ann Arbor, Michigan"),
            new Club( "Fit Happens", "333 Airport Blvd, Ann Arbor, Michigan"),
            new Club( "Curl Power", "721 Warren MI"),
            new Club( "Reps & Relaxation", "145 Westland MI")
        };

        public static void DisplayClubList(List<Club> clubList)
        {
            foreach (Club club in clubList)
                Console.WriteLine($" {club.Name}, {club.Address}");
        }

        // ADD MEMBER
        public static void AddMember(List<Member> members, List<Club> clubs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n1. Single Club Member\n2. Multi-Club Member");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Select member type: ");
            int type = int.Parse(Console.ReadLine());

            /* Console.Write("Enter Member ID: ");
            int id = int.Parse(Console.ReadLine()); */
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (type == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Select a Club:");
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 0; i < clubList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clubList[i]}");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter club number: ");
                int clubNumber = int.Parse(Console.ReadLine());
                Club assignedClub = clubList[clubNumber - 1];

                members.Add(new SingleClubMember(name, assignedClub));
            }
            else if (type == 2)
            {
                members.Add(new MultiClubMember(name));
            }
            else
            {
                Console.WriteLine("\tInvalid member type.");
            }
        }

        //REMOVE MEMBER
        public static void RemoveMember(List<Member> members, int id)
        {
            Console.Write("Enter Member ID to remove: ");
            int id1 = int.Parse(Console.ReadLine());

            var member = members.FirstOrDefault(m => m.Id == id1);

            if (member != null)
            {
                members.Remove(member);
                Console.WriteLine("Member removed successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        //Display Members
        public static void DisplayMembers(List<Member> members)
        {
            if (members.Count != 0)
            {
                Console.WriteLine("Members List: ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (Member member in members)
                {
                    Console.WriteLine($"Member ID: {member.Id} Member Name: {member.Name}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("No active members available.");
        }
    }
}
