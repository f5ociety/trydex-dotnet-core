namespace SearchApp.Engines
{
    public class Google: ISearchEngine
    {
        public string Search(string searchQuery)
        {
            // Возвращаем просто поисковой запрос
            return searchQuery;
        }
    }
}
