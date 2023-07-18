namespace CodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            Console.WriteLine("Enter the number of songs for your playlist");
            int totalnumberofsongs = int.Parse(Console.ReadLine());

            List<int> songs = new List<int>();

            for (int i = 0; i < totalnumberofsongs; i++)
            {
                songs.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine("\nPlease add another song");
            }

        }
    }
}