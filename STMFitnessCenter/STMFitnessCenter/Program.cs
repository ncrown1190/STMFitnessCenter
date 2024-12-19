// See https://aka.ms/new-console-template for more information

using STMFitnessCenter;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

//Console.ForegroundColor = ConsoleColor.Yellow;
//Console.WriteLine("\t\t\t\tWELCOME TO STM FITNESS CENTER.");
//Console.WriteLine();

//Console.ForegroundColor = ConsoleColor.Cyan;
//Console.WriteLine("Starting from Today till end of December.");
//Console.WriteLine("We offer 20% discount for limited time, available for new members only.");

List<Member> members = new List<Member>();
List<Club> clubList = new List<Club>();

Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t\t\t\tWELCOME TO STM FITNESS CENTER.");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Starting from Today till end of December.");
    Console.WriteLine("We offer 20% discount for limited time, available for new members only.");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n1. Add Member\n2. Remove Member\n3. Display Members\n4. Check In Member\n5. Generate Bill\n6. Exit\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Choose an option: ");
    int option = int.Parse(Console.ReadLine());

    try
    {
        int id = 0;
        switch (option)
        {
            case 1:
                User.AddMember(members, clubList);
                break;
            case 2:
                User.RemoveMember(members, id);
                break;
            case 3:
                User.DisplayMembers(members);
                break;
            case 4:
                User.CheckInMember(members, clubList, id);
                break;
            case 5:
                User.GenerateBill(members, id);
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Thank you for using the Fitness Center App!");
                Console.ForegroundColor= ConsoleColor.White;
                return;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}