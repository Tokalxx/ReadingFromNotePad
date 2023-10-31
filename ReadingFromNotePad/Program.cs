using System;
using System.IO;

namespace ReadingFromNotePad.Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the path to the text file.
            string filePath = "C:\\Users\\tokal\\Documents\\BCAD\\Year 3\\Seme 2\\PROG7312\\Notes\\Part3 Notes\\ReadingFromNotePad\\ReadingFromNotePad\\TextFile\\TestTextFile.txt";

            // Create a Tree instance with a root node.
            Tree tr = new Tree(new Node("0", "...", null));

            // Read all lines from the text file into an array.
            string[] lines = File.ReadAllLines(filePath);

            // Initialize the current node as the root node.
            Node currentNode = tr.Root;

            // Use a StreamReader to read the file line by line.
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                string[] subline;
                while ((line = reader.ReadLine()) != null)
                {
                    int level1 = 0;
                    int level2 = 0;

                    // Check if the line contains " - ".
                    if (line.Contains(" - "))
                    {
                        // Split the line into two parts and add a child node to the root.
                        subline = line.Split(new[] { '-' }, 2);
                        tr.Root.addNode(subline[0], subline[1]);
                    }
                    else
                    {
                        // If the line doesn't contain " - ", split it using a comma.
                        subline = line.Split(new[] { ',' }, 2);
                        level1 = Convert.ToInt32(subline[0].Substring(0, 1));
                        int callNumber = Convert.ToInt32(subline[0]);

                        // Check if the call number is a multiple of 10 and add a child node accordingly.
                        if (callNumber % 10 == 0)
                        {
                            tr.Root.Children[level1].addNode(subline[0], subline[1]);
                        }
                        else
                        {
                            level2 = Convert.ToInt32(subline[0].Substring(1, 1));

                            // Add a child node at the second level.
                            tr.Root.Children[level1].Children[level2].addNode(subline[0], subline[1]);
                        }
                    }
                }
            }

            // Generate and print the tree structure, starting from the root.
            genTree(tr.Root, 0);

            // Wait for a key press before exiting the program.
            Console.ReadKey();
        }

        // Recursively print the tree structure with proper indentation.
        public static void genTree(Node tr, int level)
        {
            foreach (Node x in tr.Children)
            {
                // Indent the node based on the level and print it.
                Console.WriteLine(new string('\t', level) + x);

                // If the node has children, recursively print them at a deeper level.
                if (x.Children.Count > 0)
                {
                    genTree(x, level + 1);
                }
            }
        }
    }
}
