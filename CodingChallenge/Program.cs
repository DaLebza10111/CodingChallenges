namespace CodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
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

            

            /*Console.WriteLine("Enter the total number of items");
            int linenumber = int.Parse(Console.ReadLine());

            int[] firstArray = new int[linenumber];
            int[] secondArray = new int[linenumber];

            Console.WriteLine("Enter the 1st collection: ");
            for (int i = 0; i < linenumber; i++)
            {
                Console.WriteLine("\nEnter a number");
                firstArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the 2nd collection: ");
            for (int i = 0; i < linenumber; i++)
            {
                Console.WriteLine("\nEnter a number");
                secondArray[i] = int.Parse(Console.ReadLine());
            }

            int minSteps = FindMinimumSteps(firstArray, secondArray);
            Console.WriteLine("Minimum steps required: " + minSteps);*/

            Console.ReadLine();
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