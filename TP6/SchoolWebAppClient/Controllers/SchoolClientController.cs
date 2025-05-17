using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TP6.Models;  // Import your model here

namespace TP6.Controllers
{
    public class SchoolClientController : Controller
    {
        private readonly HttpClient _httpClient;

        public SchoolClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SchoolApi");
        }

        public async Task<IActionResult> GetAllSchools()
        {
            var schools = await _httpClient.GetFromJsonAsync<IEnumerable<School>>("/api/schools/get-all-schools");

            return View(schools);
        }
    }
}
