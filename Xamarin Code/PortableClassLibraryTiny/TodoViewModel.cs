using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PortableClassLibrary
{
    public class TodoViewModel : BaseViewModel
    {
        public TodoViewModel()
        {
            Todos = new List<Todo>();
            Refresh();
        }

        public List<Todo> Todos
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

        private string _newTodoText;
        private List<Todo> _todos;

        public async void Refresh()
        {
            
        }

        public Task<Todo> Add(Todo todo)
        {
            Todos.Add(todo);
            return Task.FromResult(todo);
        }

        public Task<Todo> Update(Todo todo)
        {
            return Task.FromResult(todo);
        }

        public async Task Delete(Todo todo)
        {
            await Delete(todo.Id);
        }

        public Task Delete(int todoId)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == todoId);
            if (todo != null)
            {
                Todos.Remove(todo);
            }

            return Task.Run(() => { });
        }
    }
}