using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace CodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Enter the length of the string:\n");
            //int stringlength = int.Parse(Console.ReadLine());

            List<string> testcases = new List<string> { @"4 ???n aman", "4 aacb aabc", "3 ?po oyo" };
            List<string> results = new List<string> ();

            string wildcardstring = "?";
            int wildcardcount = 0;
            int count = 0;


            Console.WriteLine("Enter the number of test cases:\n");
            int NumbTests = int.Parse(Console.ReadLine());

            if ((NumbTests >= 1) || (NumbTests <= 10)) {

                for (int j = 0; j < NumbTests; j++)
                {

                    string[] stringlength = testcases[j].Split(' ');
                    int strnglngth = int.Parse(stringlength[0]);
                    string s = stringlength[1];
                    string t = stringlength[2];

                    //check for wildcards
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i].ToString() == wildcardstring)
                        {
                            wildcardcount++;
                        }
                    }

                    for (int i = 0; i < s.Length; i++)
                    {
                        for (int k = 0; k < s.Length; k++)
                        {
                            if (s[i] == t[k])
                            {
                                count++;
                            }
                        }

                    }

                    if (s.Length == (count + wildcardcount) || count == s.Length)
                    {
                        results.Add("Yes");
                    }
                    else
                    {
                        results.Add("No");
                    }

                }

            }
            else
            {
                results.Add("No");
            }

            //prints results
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        //this gets 2 space sperated numbers and uses the second number to determine how digits to remove from the 1st number
        public void Largestcombination()
        {
            Console.WriteLine("Enter row number");
            string valueinput = Console.ReadLine();
            int[] collection = valueinput.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            string DefaultNumber = collection[0].ToString();
            string digitsRemove = collection[1].ToString();

            List<int> Maxoutput = new List<int>(); //index 0 is the actual number and index 1 is the number of digits to be remove

            for (int i = 0; i < DefaultNumber.Length; i++)
            {
                Maxoutput.Add(int.Parse(DefaultNumber.Remove(i, 1)));
            }

            Console.WriteLine(Maxoutput.Max());
        }

        public void FindMaxBorder()
        {
            Console.WriteLine("Enter row number");
            int testnumbers = int.Parse(Console.ReadLine());

            List<int> sampleoutput = new List<int>();

            for (int j = 0; j < testnumbers; j++)
            {
                Console.WriteLine("Enter row number");
                int rownumber = int.Parse(Console.ReadLine());

                Console.WriteLine("\nEnter col number");
                int colnumber = int.Parse(Console.ReadLine());
                string[,] tablearray = new string[rownumber, colnumber];

                List<int> maxborders = new List<int>();

                for (int i = 0; i < rownumber; i++)
                {
                    for (int k = 0; k < colnumber; k++)
                    {
                        Console.WriteLine($"\nEnter item {k + 1} for row {i + 1}");
                        tablearray[i, k] = Console.ReadLine();
                    }
                }

                int maxrowbder = 0;
                for (int i = 0; i < rownumber; i++)
                {
                    for (int k = 0; k < colnumber; k++)
                    {
                        //check a cell after
                        if (tablearray[i, k] == "#")
                        {
                            maxrowbder += 1;
                            maxborders.Add(maxrowbder);
                        }
                    }

                    maxrowbder = 0;
                }

                sampleoutput.Add(maxborders.Max());

            }
        }

        static int FindMinimumSteps(int[] A, int[] B)
        {
            int n = A.Length;
            int minSteps = 0;

            while (true)
            {
                bool canEqualize = true;

                // Check if all elements in array A are equal
                for (int i = 1; i < n; i++)
                {
                    if (A[i] != A[0])
                    {
                        canEqualize = false;
                        break;
                    }
                }

                if (canEqualize)
                    return minSteps;

                // Find the index of the largest element in array A
                int maxIndex = 0;
                for (int i = 1; i < n; i++)
                {
                    if (A[i] > A[maxIndex])
                        maxIndex = i;
                }

                if (A[maxIndex] < B[maxIndex])
                    return -1;

                A[maxIndex] -= B[maxIndex];
                minSteps++;
            }
        }


        public void favouritesong()
        {
            Console.WriteLine("Enter the number of songs for your playlist");
            int totalnumberofsongs = int.Parse(Console.ReadLine());

            List<int> songs = new List<int>();


            for (int i = 0; i < totalnumberofsongs; i++)
            {
                Console.WriteLine("Enter a song(an in): ");
                songs.Add(int.Parse(Console.ReadLine()));

                Console.WriteLine("\nPlease add another song");
            }

            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            foreach (int song in songs)
            {
                if (frequencyMap.ContainsKey(song))
                {
                    frequencyMap[song]++;
                }
                else
                {
                    frequencyMap[song] = 1;
                }
            }

            List<int> mostAppearingNumbers = frequencyMap
                .Where(kv => kv.Value >= 2)
                .Select(kv => kv.Key)
                .ToList();

            Console.WriteLine("Numbers appearing two times or more:");

            Console.WriteLine(mostAppearingNumbers.Count);
        }
    }
}