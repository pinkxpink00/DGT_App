DGT App
The DGT App is a .NET Core application that leverages the HackerEarth Code Evaluation API to compile and run code snippets in various programming languages. The application consists of several services, including ApiService for interacting with the HackerEarth API and TaskService for managing tasks related to code execution.


1. Code Submission and Execution
Users can submit code snippets in different programming languages, and the application will interact with the HackerEarth API to compile and run the code.

2. Code Execution Status Tracking
The application allows users to track the status of their code execution requests. It includes methods to check the status of a submission using the HackerEarth API.

3. Task Management
The TaskService class provides methods for managing tasks, including retrieving, creating, updating, and deleting tasks. This can be extended to handle other application-specific tasks.

Prerequisites
.NET Core SDK
HackerEarth Code Evaluation API key
Visual Studio or any preferred code editor
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/your-username/DGT_App.git
Open the project in Visual Studio or your preferred code editor.

Replace the placeholder values for the HackerEarth API key and other configuration settings in the code.

Build and run the application.

Usage
Ensure that the application is running.

Use the user interface or application logic to submit code snippets for execution.

Track the status of code execution using the provided methods.

Manage tasks using the TaskService methods.

API Service
The ApiService class encapsulates the interaction with the HackerEarth Code Evaluation API. It includes methods for submitting code, checking code execution status, and handling API communication.

Methods:
SubmitCodeAsync: Submits code for execution and returns the result.
GetCodeStatusAsync: Retrieves the status of a code execution request.
Task Service
The TaskService class manages tasks related to code execution. It includes methods for retrieving tasks by ID, creating new tasks, updating task details, and deleting tasks.

Methods:
GetTaskByIdAsync: Retrieves a task by its ID.
CreateTaskAsync: Creates a new task and returns the ID.
UpdateTaskAsync: Updates the details of an existing task.
DeleteTaskAsync: Deletes a task by its ID.
