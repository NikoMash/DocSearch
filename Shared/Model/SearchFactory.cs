using Core;

namespace Shared.Model {
    public class SearchFactory {
        
        public static ISearchLogic GetSearchLogic() {
            return new SearchLogic(new Database());
        }
    }
}