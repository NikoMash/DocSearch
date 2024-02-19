using System;
using System.Collections.Generic;
using System.IO;
using Shared;

namespace Indexer
{
    public class App
    {
        public void Run(){
            Database db = new Database();
            Crawler crawler = new Crawler(db);

            var root = new DirectoryInfo(Paths.FOLDER);

            DateTime start = DateTime.Now;

            crawler.IndexFilesIn(root, new List<string> { ".txt"});        

            TimeSpan used = DateTime.Now - start;
            Console.WriteLine("DONE! used " + used.TotalMilliseconds);

            var all = db.GetAllWords();

            Console.WriteLine($"Indexed {db.GetDocumentCounts()} documents");
            Console.WriteLine($"Number of different words: {all.Count}");
            Console.WriteLine("How many words would you like to see?");
            int showWords = Convert.ToInt32(Console.ReadLine());
            int count = showWords;
            Console.WriteLine($"The top {count} is:");
            foreach (var p in all) {
                Console.WriteLine($"<{p.Key}, {p.Value}> -- ");
                count--;
                if (count == 0) break;
            }
        }
    }
}
