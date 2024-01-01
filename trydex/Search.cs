using SearchApp.Engines;

public class Search
    {
        public static void SendRequest(string searchQuery)
        {
            // Просто выводим поисковой запрос в консоль
            Console.WriteLine($"Отправлен поисковый запрос: {searchQuery}");
            
            
            // Создаем список поисковых двигателей
            List<ISearchEngine> searchEngines = new List<ISearchEngine>
            {
                new Google(),
                new Yandex(),
                new Github(),
                new Example(),
                new Example2(),
                new Searxng(),
            };

           

            // Отправка запроса ко всем поисковым двигателям
            foreach (var engine in searchEngines)
            {
                if (engine is Example exampleEngine)
                {
                    // Вызываем метод SearchAsync для Github
                    var searchResult = exampleEngine.Search(searchQuery);
                    Console.WriteLine($"Результат поиска в {exampleEngine.GetType().Name}: {searchResult}");
                }
                else  if (engine is Github githubEngine)
                {
                    // Вызываем метод SearchAsync для Github
                    var searchResult = githubEngine.Search(searchQuery);
                    Console.WriteLine($"Результат поиска в {githubEngine.GetType().Name}: {searchResult}");
                }
                else  if (engine is Searxng searxngEngine)
                {
                    // Вызываем метод SearchAsync для Github
                    var searchResult = searxngEngine.Search(searchQuery);
                    Console.WriteLine($"Результат поиска в {searxngEngine.GetType().Name}: {searchResult}");
                }
                else
                {
                    // Вызываем обычный метод Search для остальных поисковых двигателей
                    string result = engine.Search(searchQuery);
                    Console.WriteLine($"Результат поиска в {engine.GetType().Name}: {result}");
                }
            }
        }
    }