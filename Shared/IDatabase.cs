﻿using System.Collections.Generic;
using Shared.Model;

namespace Core
{
    public interface IDatabase
    {
        List<int> GetWordIds(string[] query, out List<string> outIgnored, bool CaseSensitive);
        List<BEDocument> GetDocDetails(List<int> docIds);
        List<KeyValuePair<int, int>> GetDocuments(List<int> wordIds);
        List<int> getMissing(int docId, List<int> wordIds);
        List<string> WordsFromIds(List<int> wordIds);
    }
}