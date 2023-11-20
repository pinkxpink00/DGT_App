using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DGT_App.Core.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ApiService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<string> SubmitCodeAsync(string language, string sourceCode, string input, int memoryLimit, int timeLimit, string context, string callbackUrl)
        {
            try
            {
                var apiUrl = "https://api.hackerearth.com/v4/partner/code-evaluation/submissions/";

                // Clear headers for each request
                _httpClient.DefaultRequestHeaders.Clear();

                // Add mandatory headers
                _httpClient.DefaultRequestHeaders.Add("content-type", "application/json");
                _httpClient.DefaultRequestHeaders.Add("client-secret", _apiKey);

                // Form the POST request body
                var requestBody = new
                {
                    lang = language,
                    source = sourceCode,
                    input = input,
                    memory_limit = memoryLimit,
                    time_limit = timeLimit,
                    context = context,
                    callback = callbackUrl
                };

                var jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"HTTP request error: {ex.Message}", ex);
            }
        }

        public async Task<string> GetCodeStatusAsync(string submissionId)
        {
            try
            {
                var apiUrl = $"https://api.hackerearth.com/v4/partner/code-evaluation/submissions/{submissionId}/";

                // Add the API key to the request header
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("client-secret", _apiKey);

                // Execute GET request
                using (HttpResponseMessage response = await _httpClient.GetAsync(apiUrl))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"HTTP request error: {ex.Message}", ex);
            }
        }
    }
}
