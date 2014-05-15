using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PghXamarinWeb.api
{
    public class TodoController : ApiController
    {
        private static readonly List<Todo> TodoDb = new List<Todo>();
        private static int _nextId = 1;

        // GET: api/Todo
        public IEnumerable<Todo> Get()
        {
            return TodoDb;
        }

        // GET: api/Todo/5
        public Todo Get(int id)
        {
            return TodoDb.FirstOrDefault(t=>t.Id == id);
        }

        // POST: api/Todo
        public Todo Post([FromBody]Todo todo)
        {
            var todoDb = TodoDb.FirstOrDefault(t => t.Id == todo.Id);
            if (todoDb == null)
            {
                todoDb = new Todo {Id = _nextId++};
                TodoDb.Add(todoDb);
            }
            todoDb.Text = todo.Text;
            todoDb.IsComplete = todo.IsComplete;
            return todoDb;
        }

        // DELETE: api/Todo/5
        [HttpDelete]
        public void Delete(int id)
        {
            var todo = TodoDb.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return;
            }
            TodoDb.Remove(todo);
        }
    }
}
