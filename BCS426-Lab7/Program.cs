using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp

{
    public abstract class Player : IComparable<Player>
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public override string ToString() => $"{ Name } { displayStatistics() }";

        public abstract string displayStatistics();

        public int CompareTo(Player other)
        {
            //throw new NotImplementedException();
            if (other == null) throw new ArgumentNullException("other");

            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Salary.CompareTo(other.Salary);
            }

            return result;
        }
    }

    public class BaseballPlayer : Player
    {
        public int AtBats { get; set; }

        public int HomeRuns { get; set; }

        public double Hits { get; set; }

        public BaseballPlayer(string name, double salary, int atBats, int homeRuns, double hits)
        {
            Name = name;
            Salary = salary;
            AtBats = atBats;
            HomeRuns = homeRuns;
            Hits = hits;
        }

        public BaseballPlayer(int i, double salary, int atBats, int homeRuns, double hits)
        {
            string num = i.ToString();
            if (i < 10) num = i.ToString() + " ";
            
            Name = "Player " + num;
            Salary = salary;
            AtBats = atBats;
            HomeRuns = homeRuns;
            Hits = hits;
        }

        public override string displayStatistics()
        {
            return $"\tAt Bats: { AtBats } \tHome Runs: {  HomeRuns } \tHits: { Hits }";
        }

    }

    class Program
    {
        static void Main()
        {
            // create a one dimensional array of baseball
            // players with size of 100
            //...
            BaseballPlayer[] player = new BaseballPlayer[100];

            // add three baseball players to the array
            //...
            player[0] = new BaseballPlayer("Max Scherzer", 43333333, 50, 20, 40);
            player[1] = new BaseballPlayer("Francisco Lindor", 32000000, 30, 5, 20);
            player[2] = new BaseballPlayer("Robinson Cano", 24000000, 200, 35, 175);

            //add remaining 100 players
            //...
            Random rand = new Random();
            for (int i = 3; i < 100; i++)
            {
                player[i] = new BaseballPlayer(i, 
                    rand.Next(1, 999999999), //salary
                    rand.Next(1, 9999), //atBats
                    rand.Next(1, 99), //homeRuns
                    rand.Next(1, 999));//hits
            }
            
            // show menu to the user
            // ask the user what option they want from 
            // the menu and accordingly display all the information 
            // of the baseball players in that specific order
            //...
            int choice;
            bool programRunning = true;
            string menu =
                "___________________________________________\n" +
                "MENU\n" +
                "----\n" +
                "1. sort players based on salary and display\n" +
                "2. sort players based on hits and display\n" +
                "3. sort players based on name and display\n" +
                "4. exit program!";

            while (programRunning)
            {
                Console.WriteLine(menu + "\n\nPlease enter a number to select your choice...");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nPlayers sorted by salary...\n\tRESULTS:\n\t--------");
                        Array.Sort(player, new BaseballPlayerCompare(BaseballPlayerCompareType.Salary));
                        foreach (BaseballPlayer p in player)
                        {
                            Console.WriteLine("\t" + p.Name + "\t with a salary of : $" + p.Salary);
                        }
                        break;
                    
                    case 2:
                        Console.WriteLine("\nPlayers sorted by htis...\n\tRESULTS:\n\t--------");
                        Array.Sort(player, new BaseballPlayerCompare(BaseballPlayerCompareType.Hits));
                        foreach (BaseballPlayer p in player)
                        {
                            Console.WriteLine("\t" + p.Name + "\t with total career hits at: " + p.Hits);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nPlayers sorted by first name...\n\tRESULTS:\n\t--------");
                        Array.Sort(player, new BaseballPlayerCompare(BaseballPlayerCompareType.Name));
                        foreach (BaseballPlayer p in player)
                        {
                            Console.WriteLine("\t" + p);
                        }
                        break;
                    case 4:
                        programRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
