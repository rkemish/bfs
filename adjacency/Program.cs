   namespace adjacency 
   {
    class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            // Adding friendships
            network.AddFriendship("Alice", "Bob");
            network.AddFriendship("Alice", "Charlie");
            network.AddFriendship("Bob", "David");
            network.AddFriendship("Charlie", "Emma");
            network.AddFriendship("David", "Fiona");
            network.AddFriendship("Emma", "Fiona");

            // Display shortest connection path
            Console.WriteLine("Social Network Shortest Connection Finder");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter the name of the first person:");
            string person1 = Console.ReadLine();

            Console.WriteLine("Enter the name of the second person:");
            string person2 = Console.ReadLine();

            network.FindShortestConnection(person1, person2);
        }
    }
}