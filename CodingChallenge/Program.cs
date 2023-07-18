namespace CodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadLine();
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