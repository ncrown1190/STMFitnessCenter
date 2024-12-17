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
            DateTime now = DateTime.Now;
            double discount = 0.0; // Apply discounts based on the current date
            if (now.Month == 12) // Example: Apply discounts in December
            {
                discount = 0.2; // 20% discount
            }

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

                Member newMember = null;
                newMember = new SingleClubMember(name, assignedClub);
                newMember.Discount = discount;
                members.Add(newMember);

                Console.WriteLine($"Single Club Member added with a {discount * 100}% discount.");

                //members.Add(new SingleClubMember(name, assignedClub));
            }
            else if (type == 2)
            {
                Member newMember = null;
                newMember = new MultiClubMember(name);
                newMember.Discount = discount;
                members.Add(newMember);
                //members.Add(new MultiClubMember(name));

                Console.WriteLine($"Multi club Member added with a {discount * 100}% discount");
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
            else
            {
                Console.WriteLine("No active members available.");
            }            
        }

        //Check members in 

        public static void CheckInMember(List<Member> members, List<Club> clubs, int id)
        {
            Console.Write("Enter Member ID to check in: ");
            int idToCheckIn = int.Parse(Console.ReadLine());

            var member = members.FirstOrDefault(m => m.Id == idToCheckIn);
            if (member != null)
            {
                Console.WriteLine("Select a club: ");
                for (int i = 0; i < clubList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.  {clubList[i]}");
                }
                Console.Write("Enter club number: ");
                int clubNumber = int.Parse(Console.ReadLine());
                Club selectedClub = clubList[clubNumber - 1];

                try
                {
                    member.CheckIn(selectedClub);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" An error occured. {ex.Message}");

                } 
            }
            else
            {
                Console.WriteLine("Member not found!");
            }
        }

public static void GenerateBill(List<Member> members, int id)
        {
            Console.Write("Enter Member ID to generate bill: ");
            int idToGenerateBill = int.Parse(Console.ReadLine());

            var member = members.FirstOrDefault(m => m.Id == idToGenerateBill);
            if(member != null)
            {
                Console.WriteLine($"Bill for {member.Name}: ");
                if(DateTime.Now.Month == 12)
                {
                    if(member is MultiClubMember multiClubMember)
                    {
                        Console.WriteLine($"Membership Points: {multiClubMember.MembershipPoints}");
                        Console.WriteLine($"Standard Multi Club Member fee is ${100}");
                        Console.WriteLine($"Total Fee: ${multiClubMember.MembershipPoints * 0.5 + (100) * 0.8}");
                    }
                    else
                    {
                        Console.WriteLine($"Standard Single Club Member fee is ${150}");
                        Console.WriteLine($"Total fee with 20% discount: ${150 * 0.8}");
                    }
                }

            }
        }
    }
}
