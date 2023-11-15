using System.Net.Http;
using System.Windows;
using DGT_App.Core.Services;
using DGT_App.ViewModels;

namespace DGT_App
{
    public partial class MainWindow : Window
    {
        private readonly TaskService _taskService;

        public MainWindow()
        {
            InitializeComponent();
            
            _taskService = new TaskService(new ApiService(new HttpClient(), "70c9f299c6c510bb76386e0f996956ba8cadde50"));

            DataContext = new MainViewModel(_taskService);
        }
    }
}