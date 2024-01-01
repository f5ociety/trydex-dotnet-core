namespace SearchApp.Engines
{
    public class Yandex: ISearchEngine
    {
        public string Search(string searchQuery)
        {
            // Возвращаем просто поисковой запрос
            return searchQuery;
        }
    }
}
