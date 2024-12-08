using System;
using System.Collections.Generic;

namespace adjacency
{
    class SocialNetwork
    {
        private Dictionary<string, List<string>> AdjacencyList; // Adjacency list for the graph

        public SocialNetwork()
        {
            AdjacencyList = new Dictionary<string, List<string>>();
        }

        // Add a friendship (edge) between two people
        public void AddFriendship(string person1, string person2)
        {
            if (!AdjacencyList.ContainsKey(person1))
                AdjacencyList[person1] = new List<string>();

            if (!AdjacencyList.ContainsKey(person2))
                AdjacencyList[person2] = new List<string>();

            AdjacencyList[person1].Add(person2);
            AdjacencyList[person2].Add(person1); // Undirected graph
        }

        // Find the shortest connection path using BFS
        public void FindShortestConnection(string startPerson, string targetPerson)
        {
            if (!AdjacencyList.ContainsKey(startPerson) || !AdjacencyList.ContainsKey(targetPerson))
            {
                Console.WriteLine("One or both people are not in the network.");
                return;
            }

            Queue<string> queue = new Queue<string>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Dictionary<string, string> parent = new Dictionary<string, string>();

            // Initialize visited and parent dictionaries
            foreach (var person in AdjacencyList.Keys)
            {
                visited[person] = false;
                parent[person] = null;
            }

            // Start BFS
            visited[startPerson] = true;
            queue.Enqueue(startPerson);

            while (queue.Count > 0)
            {
                string currentPerson = queue.Dequeue();

                // Stop if we find the target person
                if (currentPerson == targetPerson)
                    break;

                foreach (var friend in AdjacencyList[currentPerson])
                {
                    if (!visited[friend])
                    {
                        visited[friend] = true;
                        parent[friend] = currentPerson;
                        queue.Enqueue(friend);
                    }
                }
            }

            // Backtrack to find the path
            List<string> path = new List<string>();
            string step = targetPerson;

            while (step != null)
            {
                path.Add(step);
                step = parent[step];
            }

            path.Reverse(); // Reverse to get the path from start to target

            // Output the path
            if (path[0] == startPerson)
            {
                Console.WriteLine($"Shortest connection path between {startPerson} and {targetPerson}:");
                Console.WriteLine(string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine($"No connection path exists between {startPerson} and {targetPerson}.");
            }
        }
    }
}