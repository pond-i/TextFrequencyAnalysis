using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

// Frequency  Analysis Application
// Tested with 3 test data sets; SampleDataset.txt, IllegalCharacterDataSet.txt and LargeDataSet.txt.
// Application to be launched via CLI with parameters of given .txt file.

namespace FrequencyAnalysis

{
    public class Program
    {

        public static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("Invalid / file not found. Check application parameters.");
                return;
            }

            // Case sensitive switch; true by default.
            bool caseSensitive = true;

            // Begin user selection for case sensitivity.
            Console.WriteLine("Frequency analysis started with file " + args[0] + ".");
            Console.WriteLine("Would you like case sensitive formatting? Y/N");

            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "y" or "yes":
                    Console.WriteLine("Case sensitivity is on.");
                    caseSensitive = true;
                    break;
                case "n" or "no":
                    Console.WriteLine("Case sensitivity is off.");
                    caseSensitive = false;
                    break;
                default:
                    Console.WriteLine("Y/N not selected, case sensitivity will remain default. (On)");
                    break;
            }

            string path = args[0];

            try
            {
                ProcessText(path, caseSensitive);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public static void ProcessText(string path, bool isCaseSensitive)
        {
            Console.WriteLine("Processing text has started.");

            // Get text data.
            string data = GetData(path);

            if (!string.IsNullOrEmpty(data))
            {
                // Iterate through given data.
                // Return sorted character dictionary, total ignored characters, total valid characters and iteration process time.
                var (SortedCharacters, IgnoredCharacters, AcceptedCharacters, TimeElapsed) = IterateData(data, isCaseSensitive);

                string resultAcceptedTotal = ("Total characters: " + AcceptedCharacters.ToString("0,0", CultureInfo.InvariantCulture));
                string resultIgnoredTotal = ("Total ignored characters: " + IgnoredCharacters.ToString("0,0", CultureInfo.InvariantCulture));

                // Display results in console.
                Console.WriteLine("\nResult Output:\n");
                Console.WriteLine(TimeElapsed);
                Console.WriteLine(resultAcceptedTotal);
                Console.WriteLine(resultIgnoredTotal);

                // Sort character dictionary.
                // Iterate log through 10 items.
                List<string> resultList = new();
                var sortedCharCounter = GetSortedCharacterCounter(SortedCharacters);
                foreach (var kvp in sortedCharCounter.Take(10))
                {
                    string line = $"{kvp.Key}:({kvp.Value})";
                    Console.WriteLine(line);
                    resultList.Add(line);
                }

            }
            else
            {
                Console.WriteLine("Invalid sample text provided. Please check file " + path + ".");
            }
        }

        public static string GetData(string path)
        {
            // Reading data with given path.
            StreamReader sr = new(path);
            string dataText = sr.ReadToEnd();
            sr.Close();

            return dataText;
        }

        public static (Dictionary<char, int> SortedCharacters, int IgnoredCharacters, int AcceptedCharacters, string TimeElapsed) IterateData(string data, bool isCaseSensitive)
        {
            // Null check data.
            if (string.IsNullOrEmpty(data))
            {
                return (new Dictionary<char, int>(), 0, 0, "");
            }

            Dictionary<char, int> SortedCharacters = new();
            int IgnoredCharacters = 0;
            int AcceptedCharacters = 0;

            // Set rule pattern for only including a-z, A-Z and 0-9.
            string regexPattern = "[^a-zA-Z0-9]";

            Stopwatch timer = new();
            timer.Start();

            // Iterate through data.
            foreach (char c in data)
            {
                // Ignore character if not pattern criteria. 
                if (!Regex.IsMatch(c.ToString(), regexPattern))
                {
                    // Character is valid.
                    // Check if case sensitivity was enabled earlier; lower case character if false.
                    char characterToCount = isCaseSensitive ? c : char.ToLower(c);

                    // Check if character is already in dict;
                    // Add to total if it is, otherwise create new kvp.
                    if (SortedCharacters.ContainsKey(characterToCount))
                    {
                        SortedCharacters[characterToCount]++;
                    }
                    else
                    {
                        SortedCharacters[characterToCount] = 1;
                    }
                    AcceptedCharacters++;
                }
                else
                {
                    // Add ignored character to counter; move next.
                    IgnoredCharacters++;
                }
            }

            timer.Stop();

            // Store process time.
            string TimeElapsed = "\nTime Elapsed: " + timer.ElapsedMilliseconds + "ms";

            return (SortedCharacters, IgnoredCharacters, AcceptedCharacters, TimeElapsed);
        }

        public static IEnumerable<KeyValuePair<char, int>> GetSortedCharacterCounter(Dictionary<char, int> charCounter)
        {
            // Sort counted data to order by descending and take top 10.
            return charCounter.OrderByDescending(pair => pair.Value).Take(10);
        }

    }
}