using System;

namespace ManateeApplication
{
    public class ManateeSighting
    {
        string location;
        string[] sightDates;
        int[] manateeCount;
        public ManateeSighting(string location, string[] sightDates, int[] manateeCount)
        {
            this.location = location;
            this.sightDates = sightDates;
            this.manateeCount = manateeCount;
        }
        

        double CalculateAverage()
        {
            return 1;
        }

        int GetIndexOfMostSightings()
        {
            return 1;
        }

        int GetMostSightings()
        {
            return 1;
        }

        string GetDateWithMostSightings()
        {
            return "hello";
        }

        string GetMonthWithMostSightings()
        {
            return "hello";
        }

        double ComputeAverageForMonth()
        {
            return 1;
        }

        string ToString()
        {
            return "";
        }
    }



    class ManateeApp
    {
        public static int GetData(out string location, string[] dateArray, int[] manateeCount)
        {
            Console.Write("Location: ");
            location = Console.ReadLine();
            Console.WriteLine("How many records for {0}", location);

            int recordsCount = 0;
            bool checkParse = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out int records))
                {
                    recordsCount = records;
                    checkParse = true;
                }
                else
                {
                    Console.WriteLine("Couldn't parse your input, re-enter");
                }
            } while (!checkParse);


            for (int i = 0; i < recordsCount; i++)
            {
                Console.Write("Date: [mm/dd/yy]: ");
                string dateInput = Console.ReadLine();
                if (dateInput == "")
                {
                    dateArray[i] = "No date entered - Unknown recorded for sightings";
                }

                Console.Write("Number of sightings: ");
                string numOfSightings;
                checkParse = false;
                do
                {
                    numOfSightings = Console.ReadLine();

                    if (numOfSightings == "")
                    {
                        Console.WriteLine("Number of sightings cannot be empty");
                    }
                    else
                    {
                        if (int.TryParse(numOfSightings, out int count))
                        {
                            manateeCount[i] = count;
                            checkParse = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                } while (!checkParse);
            }
            return recordsCount;
        }
        static void Main(string[] args)
        {
            string location;
            int sightingCount;
            string[] dateArray = new string[50]; // What is the max?
            int[] manateeCount = new int[50]; // What is the max?
            ManateeSighting m;
            sightingCount = GetData(out location, dateArray, manateeCount);
            m = new ManateeSighting(location, dateArray, manateeCount);


            Console.WriteLine("Hello World!");
        }
    }
}
