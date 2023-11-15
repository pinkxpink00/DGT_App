using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Newtonsoft;
=======
using Newtonsoft.Json;

>>>>>>> 44eb7b1a5e74833e229fa5c1b64c93e7a389734b

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

<<<<<<< HEAD
                // Add the API key to the request header
                _httpClient.DefaultRequestHeaders.Add("client-secret", "70c9f299c6c510bb76386e0f996956ba8cadde50");

                // Form the POST request body
=======
                //  add a key API to a query header
                _httpClient.DefaultRequestHeaders.Add("client-secret", _apiKey);

                // POST REQUEST Body Shaping
>>>>>>> 44eb7b1a5e74833e229fa5c1b64c93e7a389734b
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

<<<<<<< HEAD
                
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                // Test request success
=======
                // Post query execution
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                // Request success check
>>>>>>> 44eb7b1a5e74833e229fa5c1b64c93e7a389734b
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> GetCodeStatusAsync(string submissionId)
        {
            try
            {
                var apiUrl = $"https://api.hackerearth.com/v4/partner/code-evaluation/submissions/{submissionId}/";

                // To add a key API to a query header
                _httpClient.DefaultRequestHeaders.Add("client-secret", _apiKey);

                // Executing GET-Query
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                // Request success check
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
