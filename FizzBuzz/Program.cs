using System;
using System.Data.Entity;

namespace FizzBuzz
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
            Console.WriteLine(FizzBuzzGame.checkNumber(number));
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

        public static string checkNumber(int num)
        {

            string answer = "";

            using(var db = new FBContext())
            {

                var instance0 = new FBInstance();


                if (num % 3 == 0 && num % 5 == 0)
                {
                    answer = "FizzBuzz";
                    instance0.Number = num;
                    instance0.Type = answer;
                    db.FBInstances.Add(instance0);
                    db.SaveChanges();
                }
                else if (num % 3 == 0)
                {
                    answer = "Fizz";
                    instance0.Number = num;
                    instance0.Type = answer;
                    db.FBInstances.Add(instance0);
                    db.SaveChanges();
                }
                else if (num % 5 == 0)
                {
                    answer = "Buzz";
                    instance0.Number = num;
                    instance0.Type = answer;
                    db.FBInstances.Add(instance0);
                    db.SaveChanges();
                }
                else
                {
                    answer = $"{num} is not a multiple of 3 or 5";
                    instance0.Number = num;
                    instance0.Type = "N/A";
                    db.FBInstances.Add(instance0);
                    db.SaveChanges();
                }

               // return answer;
            }

            return answer;
            //if (num % 3 == 0 && num % 5 == 0) answer = "FizzBuzz";
            //else if (num % 3 == 0) answer = "Fizz";
            //else if (num % 5 == 0) answer = "Buzz";
            //else answer = $"{num} is not a multiple of 3 or 5";
            //return answer;
        }
    }

    public class FBInstance
    {
        public int FbID { get; set; }

        public int Number { get; set; }
        public string Type { get; set; }

        
    }

    public class FBContext : DbContext
    {
        public FBContext() : base("TestDB") { }

        public DbSet<FBInstance> FBInstances { get; set; }
    }


}
