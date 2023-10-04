using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.DTO;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory httpClientFactory;

        [BindProperty]
        public List<WeatherForecast> weatherForecasts { get; set; } = new List<WeatherForecast>();
        public IndexModel(ILogger<IndexModel> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var httpClient = httpClientFactory.CreateClient("OurWebApi");
            weatherForecasts = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast") ?? new List<WeatherForecast>();
        }
    }
}