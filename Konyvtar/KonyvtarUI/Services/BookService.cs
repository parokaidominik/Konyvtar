using KonyvtarAPI;
using KonyvtarUI;
using System.Net.Http.Json;

namespace KonyvtarUI.Services
{
    public class BooksService
    {
        private List<Book> books;
        private readonly HttpClient http;

        public BooksService(HttpClient http)
        {
            this.http = http;
            // Tényleges adatbázisból való betöltés
            LoadBooksAsync().Wait(); // Megvárjuk az aszinkron művelet befejezését a konstruktorban
        }

        public async Task<bool> IsInventoryNumberExistsAsync(string inventoryNumber)
        {
            await LoadBooksAsync(); // Biztosítjuk, hogy az adatok betöltődtek

            return true;
        }

        private async Task LoadBooksAsync()
        {
            try
            {
                if (books == null)
                {
                    books = await http.GetFromJsonAsync<List<Book>>("data/books.json");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a könyvek betöltése közben: {ex.Message}");
            }
        }
    }
}
