using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DGT_App.Core.Commands;
using DGT_App.Core.Models;
using DGT_App.Core.Services;
using Newtonsoft.Json;

namespace DGT_App.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly TaskService _taskService;
        private ObservableCollection<LanguageModel> _languages;
        private LanguageModel _selectedLanguage;
        private string _sourceCode;
        private string _errorMessage;

        public ObservableCollection<LanguageModel> Languages
        {
            get { return _languages; }
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    OnPropertyChanged();
                }
            }
        }

        public LanguageModel SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SourceCode
        {
            get { return _sourceCode; }
            set
            {
                if (_sourceCode != value)
                {
                    _sourceCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RunCodeCommand { get; }

        public MainViewModel(TaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));

            Languages = new ObservableCollection<LanguageModel>
            {

                new LanguageModel { DisplayName = "C", Tag = "C" },
                new LanguageModel { DisplayName = "C++14", Tag = "CPP14" },
                new LanguageModel { DisplayName = "C++17", Tag = "CPP17" },
                new LanguageModel { DisplayName = "Clojure", Tag = "CLOJURE" },
                new LanguageModel { DisplayName = "C#", Tag = "CSHARP" },
                new LanguageModel { DisplayName = "Go", Tag = "Go" },
                new LanguageModel { DisplayName = "Haskell", Tag = "HASKELL" },
                new LanguageModel { DisplayName = "Java 8", Tag = "JAVA8" },
                new LanguageModel { DisplayName = "Java 14", Tag = "JAVA14" },
                new LanguageModel { DisplayName = "JavaScript(Nodejs)", Tag = "JAVASCRIPT_NODE" },
                new LanguageModel { DisplayName = "Kotlin", Tag = "KOTLIN" },
                new LanguageModel { DisplayName = "Objective C", Tag = "OBJECTIVEC" },
                new LanguageModel { DisplayName = "Pascal", Tag = "PASCAL" },
                new LanguageModel { DisplayName = "Perl", Tag = "PERL" },
                new LanguageModel { DisplayName = "PHP", Tag = "PHP" },
                new LanguageModel { DisplayName = "Python 2", Tag = "PYTHON" },
                new LanguageModel { DisplayName = "Python 3", Tag = "PYTHON3" },
                new LanguageModel { DisplayName = "Python 3.8", Tag = "PYTHON3_8" },
                new LanguageModel { DisplayName = "R", Tag = "R" },
                new LanguageModel { DisplayName = "Ruby", Tag = "RUBY" },
                new LanguageModel { DisplayName = "Rust", Tag = "RUST" },
                new LanguageModel { DisplayName = "Scala", Tag = "SCALA" },
                new LanguageModel { DisplayName = "Swift", Tag = "SWIFT" },
                new LanguageModel { DisplayName = "TypeScript", Tag = "TYPESCRIPT" },
            };

            RunCodeCommand = new RelayCommand(ExecuteRunCodeCommand, CanExecuteRunCodeCommand);
        }

        private async void ExecuteRunCodeCommand(object parameter)
        {
            
            if (SelectedLanguage == null)
            {
                
                ShowMessage("Please select a programming language.");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(SourceCode))
            {
                
                ShowMessage("Please enter code before running.");
                return;
            }

            
            var requestId = Guid.NewGuid().ToString();

            
            var submissionResult = await _taskService.ExecuteCodeAsync(
                SelectedLanguage.Tag,
                SourceCode,
                input: "",
                memoryLimit: 256, 
                timeLimit: 1000, 
                context: "sandbox",
                callbackUrl: $"https://client.com/callback/" 
            );

           
            Console.WriteLine(submissionResult);

            
            if (submissionResult.Contains("Error"))
            {
                
                var errorMessage = ParseErrorMessage(submissionResult);
                ShowMessage($"Error: {errorMessage}");
            }
            else
            {
               
                ShowMessage("Code submitted successfully. Waiting for results...");
            }

            
        }

        
        private void ShowMessage(string message)
        {
            
            ErrorMessage = message;
            
            Console.WriteLine(message);
        }

        
        private string ParseErrorMessage(string submissionResult)
        {
            
            return submissionResult;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool CanExecuteRunCodeCommand(object parameter)
        {
            
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}