using KonyvtarAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using KonyvtarUI.Pages.Models;

namespace KonyvtarUI.Services
{
    public class ReadersService
    {
        private List<Reader> readers;
        private readonly HttpClient http;

        public ReadersService(HttpClient http)
        {
            this.http = http;
            // Tényleges adatbázisból való betöltés
            LoadReadersAsync().Wait(); // Megvárjuk az aszinkron művelet befejezését a konstruktorban
        }

        public async Task<bool> IsReaderNumberExistsAsync(string readerNumber)
        {
            await LoadReadersAsync(); // Biztosítjuk, hogy az adatok betöltődtek

            return  false;
        }

        private async Task LoadReadersAsync()
        {
            try
            {
                if (readers == null)
                {
                    readers = await http.GetFromJsonAsync<List<Reader>>("data/readers.json");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba az olvasók betöltése közben: {ex.Message}");
            }
        }
    }
}
