using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMFitnessCenter
{
    public class AccessMemberId
    {
        public static int ChooseMember(List<Member> membersList)
        {
            int memberId = 0;
            bool notValid = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\nFor members List: 0  \nReturn to main menu: Q \nFor Individual Enter Member ID:  ");
                Console.ForegroundColor = ConsoleColor.White;
                string idOrList = Console.ReadLine().ToLower();

                if (int.TryParse(idOrList, out memberId))
                {
                    if (memberId == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        DisplayMembers(membersList);
                        Console.ForegroundColor = ConsoleColor.White;
                        notValid = true;
                    }
                    else if (membersList.Contains(membersList.Where(x => x.Id == memberId).FirstOrDefault()))
                    {
                        notValid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The member Id entered, {memberId}, does not match any members on the list. Please try again. ");
                        Console.ForegroundColor = ConsoleColor.White;
                        notValid = true;
                    }
                }
                else
                {
                    if (idOrList == "q")
                    {
                        notValid = false;
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else
                        notValid = true;
                }

            }
            while (notValid == true);

            return memberId;
        }

        public static void DisplayMembers(List<Member> membersList)
        {
            Console.WriteLine();
            foreach (Member member in membersList)
            {
                Console.WriteLine($"ID: {member.Id} Member Name: {member.Name}");
            }
            Console.WriteLine();
        }
    }
}
