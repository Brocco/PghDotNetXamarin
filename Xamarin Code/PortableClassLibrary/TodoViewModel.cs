using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PortableClassLibrary
{
    public class TodoViewModel : BaseViewModel
    {
        public TodoViewModel()
        {
            Todos = new ObservableCollection<Todo>();
            Refresh();
        }

        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set
            {
                if (Equals(value, _todos)) return;
                _todos = value;
                OnPropertyChanged();
            }
        }

        public string NewTodoText
        {
            get { return _newTodoText; }
            set
            {
                if (value == _newTodoText) return;
                _newTodoText = value;
                OnPropertyChanged();
            }
        }

        private string apiUrl = @"http://pghxamarin.azurewebsites.net/api/todo";
        private string _newTodoText;
        private ObservableCollection<Todo> _todos;

        public async void Refresh()
        {
            var response = await Http.Get(apiUrl);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return;
            }
            var responseString = await Http.GetContentString(response);
            var responseObject = JsonConvert.DeserializeObject<ObservableCollection<Todo>>(responseString);
            Todos = responseObject;
        }

        public async Task<Todo> Add(Todo todo)
        {
            return await Update(todo);
        }

        public async Task<Todo> Update(Todo todo)
        {
            var kvps = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("id", todo.Id.ToString()),
                new KeyValuePair<string, string>("text", todo.Text),
                new KeyValuePair<string, string>("isComplete", todo.IsComplete.ToString())
            };
            var response = await Http.Post(apiUrl, kvps);
            var responseString = await Http.GetContentString(response);
            var responseObject = JsonConvert.DeserializeObject<Todo>(responseString);
            return responseObject;
        }

        public async Task Delete(Todo todo)
        {
            await Delete(todo.Id);
        }

        public async Task Delete(int todoId)
        {
            var url = apiUrl;
            url += "?id=" + todoId;
            await Http.Delete(url);
        }
    }
}