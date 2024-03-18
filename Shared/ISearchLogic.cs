using System;

namespace Core {
    
    public interface ISearchLogic {
        
        public SearchResult Search(String[] query, int maxAmount, bool CaseSensitive);
    };
}