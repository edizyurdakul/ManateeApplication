using System;
using System.Globalization;

namespace ManateeApplication
{
    public class ManateeSighting
    {
        string location;
        string[] sightDates;
        int[] manateeCount;
        int sightingCount;
        public ManateeSighting(string location, string[] sightDates, int[] manateeCount, int sightingCount)
        {
            this.location = location;
            this.sightDates = sightDates;
            this.manateeCount = manateeCount;
            this.sightingCount = sightingCount;
        }

        public double CalculateAverage()
        {
            double totalSightings = 0;
            foreach(int count in manateeCount)
            {
                totalSightings = totalSightings + count;
            }
            return totalSightings / sightingCount;
        }

        public int GetIndexOfMostSightings()
        {
            int index = 0;
            int highest = 0;
            for(int i = 0; i < sightingCount; i++)
            {
                if(manateeCount[i] > highest)
                {
                    highest = manateeCount[i];
                    index = i;
                }
            }
             
            return index;
        }

        public int GetMostSightings()
        {
            return manateeCount[GetIndexOfMostSightings()];
        }

        public string GetDateWithMostSightings()
        {
            return sightDates[GetIndexOfMostSightings()];
        }

        public string GetMonthWithMostSightings()
        {

            if (DateTime.TryParseExact(GetDateWithMostSightings(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                return dateValue.ToString("MMMM");
            } else if (DateTime.TryParseExact(GetDateWithMostSightings(), "M/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                return dateValue.ToString("MMMM");
            } else if (DateTime.TryParseExact(GetDateWithMostSightings(), "MM/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                return dateValue.ToString("MMMM");
            } else if (DateTime.TryParseExact(GetDateWithMostSightings(), "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                return dateValue.ToString("MMMM");
            } else
            {
                return "Something went wrong";
            }
        }

        public double ComputeAverageForMonth(string date)
        {
            int sightingCountPerMonth = 0;
            int total = 0;
            string month = DateTime.ParseExact(date, "MM/dd/yy", CultureInfo.InvariantCulture).ToString("MMMM");

            for(int i = 0; i < sightingCount; i++)
            {
                if(month == sightDates[i])
                {
                    total = manateeCount[i];
                    sightingCountPerMonth++;
                }
            }

            return total/sightingCountPerMonth;
        }

        public string ToString()
        {
            return String.Format("\nLocation: \t{0}\nAverage number of sightings: \t{1}" +
                "\nMonth name for the date with most sightings: \t{2}" +
                "\nDate of most sightings: \t{3}\nCount for {4}: \t{5}", 
                location, CalculateAverage(), GetMonthWithMostSightings(), 
                GetDateWithMostSightings(), GetDateWithMostSightings(), 
                GetMostSightings());
            
        }
    }



    class ManateeApp
    {
        public static int GetData(out string location, string[] dateArray, int[] manateeCount)
        {
            Console.Write("Location: ");
            location = Console.ReadLine();
            Console.WriteLine("\nHow many records for {0}", location);

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
                    Console.WriteLine("\nCouldn't parse your input, re-enter");
                }
            } while (!checkParse);


            for (int i = 0; i < recordsCount; i++)
            {
                Console.Write("\nDate: [mm/dd/yy]: ");
                string dateInput = Console.ReadLine();
                if (dateInput == "")
                {
                    dateArray[i] = "\nNo date entered - Unknown recorded for sightings";
                } else
                {
                    dateArray[i] = dateInput;
                }
 
                Console.Write("\nNumber of sightings: ");
                string numOfSightings;
                checkParse = false;
                do
                {
                    numOfSightings = Console.ReadLine();

                    if (numOfSightings == "")
                    {
                        Console.WriteLine("\nNumber of sightings cannot be empty");
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
                            Console.WriteLine("\nInvalid input re-enter");
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
            string moreData = "y";

            do
            {
                sightingCount = GetData(out location, dateArray, manateeCount);
                ManateeSighting m = new ManateeSighting(location, dateArray, manateeCount, sightingCount);
                Console.WriteLine(m.ToString());


                Console.WriteLine("Enter more data? [y/n] ");
                moreData = Console.ReadLine();
                if (moreData == "")
                {
                    Console.WriteLine("Invalid");
                    moreData = "n";
                }
            } while (moreData.Equals("y", StringComparison.OrdinalIgnoreCase));
            
        }
    }
}
