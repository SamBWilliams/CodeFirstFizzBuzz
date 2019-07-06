using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FizzBuzzNotCore
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzGame.start();

            string n;
            Console.WriteLine("Enter a number: ");
            n = Console.ReadLine();
            int number = Convert.ToInt32(n);
            Console.WriteLine(FizzBuzzGame.checkNumberToTest(number));
            FizzBuzzGame.checkForFizzBuzz(number);
        }




    }
    public class FizzBuzzGame
    {

        public static void start()
        {

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0) Console.WriteLine("Fizz");
                else if (i % 5 == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);

            }
        }

        public static string checkNumberToTest(int num)
        {
            string answer = "";

            if (num % 3 == 0 && num % 5 == 0) answer = "FizzBuzz";
            else if (num % 3 == 0) answer = "Fizz";
            else if (num % 5 == 0) answer = "Buzz";
            else answer = $"{num} is not a multiple of 3 or 5";

            return answer;
        }

        public static void checkForFizzBuzz(int num)
        {
            string answer = "";


            if (num % 3 == 0 && num % 5 == 0)
            {
                answer = "FizzBuzz";
                addToDB(num, answer);
            }
            else if (num % 3 == 0)
            {
                answer = "Fizz";
                addToDB(num, answer);
            }
            else if (num % 5 == 0)
            {
                answer = "Buzz";
                addToDB(num, answer);
            }
            else
            {
                answer = $"{num} is not a multiple of 3 or 5";
                addToDB(num, answer);
            }
        }

        public static void addToDB(int num, string ans)
        {
            using (var db = new FBContext())
            {
                var inst = new FBInstance();

                inst.Number = num;
                inst.Type = ans;

                db.FBInstances.Add(inst);
                db.SaveChanges();
            }
        }
    }

    public class FBInstance
    {
        public int ID { get; set; }

        public int Number { get; set; }
        public string Type { get; set; }


    }

    public class FBContext : DbContext
    {
        public FBContext() : base("TestDB") { }

        public DbSet<FBInstance> FBInstances { get; set; }
    }
}
