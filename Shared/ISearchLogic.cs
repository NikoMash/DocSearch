using System;

namespace Shared {
    
    public interface ISearchLogic {
        
        public SearchResult Search(String[] query, int maxAmount, bool CaseSensitive);
    };
}