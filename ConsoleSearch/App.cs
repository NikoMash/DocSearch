using System;
using Shared.Model;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ConsoleSearch
{
    public class App
    {
        public App()
        {
        }

        public void Run()
        {
            SearchLogic mSearchLogic = new SearchLogic(new Database());
            Config config = new();

            Console.WriteLine("Console Search");
            
            while (true)
            {
                Console.WriteLine("enter search terms - q for quit");
                Console.WriteLine("To change settings type 'settings'");
                Console.WriteLine($"Case sensitivity: {config.CaseSensitive}");
                string input = Console.ReadLine();
                if (input.Equals("q")) break;

                if (input.Equals("settings")) {
                    Console.WriteLine("To turn off case sensitivity write 'cs=off'");
                    string command = Console.ReadLine();

                    if (command.Equals("cs=off")) {
                        config.CaseSensitive = false;
                    } else if (command.Equals("cs=on")) {
                        config.CaseSensitive = true;
                    }
                } 
                else {
                
                var query = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var result = mSearchLogic.Search(query, 10, config.CaseSensitive);

                if (result.Ignored.Count > 0) {
                    Console.WriteLine($"Ignored: {string.Join(',', result.Ignored)}");
                }

                int idx = 1;
                foreach (var doc in result.DocumentHits) {
                    Console.WriteLine($"{idx} : {doc.Document.mUrl} -- contains {doc.NoOfHits} search terms");
                    Console.WriteLine("Index time: " + doc.Document.mIdxTime);
                    Console.WriteLine($"Missing: {ArrayAsString(doc.Missing.ToArray())}");
                    idx++;
                }
                Console.WriteLine("Documents: " + result.Hits + ". Time: " + result.TimeUsed.TotalMilliseconds);
                }
            }
        }

        string ArrayAsString(string[] s) {
            return s.Length == 0?"[]":$"[{String.Join(',', s)}]";
            //foreach (var str in s)
            //    res += str + ", ";
            //return res.Substring(0, res.Length - 2) + "]";
        }
    }
}
