using Core;

namespace SearchApi.Logic
{
    public class SearchFactory
    {
        public static ISearchLogic GetSearchLogic()
        {
            return new SearchLogic(new Database());
        }
    }
}