internal class Program
{
    private static void Main(string[] args)
    {
        // Ввод строки поискового запроса
            Console.Write("Введите поисковый запрос: ");
            string searchQuery = Console.ReadLine();

            // Вызов функции SendRequest из класса Search
            Search.SendRequest(searchQuery);
    }
}

