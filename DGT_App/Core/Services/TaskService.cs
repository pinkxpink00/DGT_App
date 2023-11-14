using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DGT_App.Core.Models;

namespace DGT_App.Core.Services
{
    public class TaskService
    {
        private readonly ApiService _apiService;

        public TaskService(ApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        // Method for executing code using the HackerEarth Open API
        public async Task<string> ExecuteCodeAsync(string language, string sourceCode, string input, int memoryLimit, int timeLimit, string context, string callbackUrl)
        {
            // Prepare data for the request
            var requestData = new
            {
                lang = language,
                source = sourceCode,
                input,
                memory_limit = memoryLimit,
                time_limit = timeLimit,
                context,
                callback = callbackUrl
            };

            // Serialize data to JSON
            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Call the method from ApiService to execute the code
            var submissionResult = await _apiService.SubmitCodeAsync(language, sourceCode, input, memoryLimit, timeLimit, context, callbackUrl);

            return submissionResult;
        }

        // Method for getting the code execution status
        public async Task<string> GetCodeExecutionStatusAsync(string submissionId)
        {
            // Call the method from ApiService to get the status
            var status = await _apiService.GetCodeStatusAsync(submissionId);

            return status;
        }
        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            
            throw new NotImplementedException();
        }

       
        public async Task<int> CreateTaskAsync(TaskModel task)
        {
           
            throw new NotImplementedException();
        }

        
        public async Task<bool> UpdateTaskAsync(int taskId, TaskModel updatedTask)
        {
            
            throw new NotImplementedException();
        }

        
        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            
            throw new NotImplementedException();
        }
    }

}
