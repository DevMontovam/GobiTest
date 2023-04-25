namespace Gobi.Test.Jr.Domain.Interfaces
{
	public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();
        IReadOnlyList<TodoItem> GetOne(int id);
        void Add(TodoItem todoItem);
        void Edit(TodoItem todoItem);
        void Delete(TodoItem todoItem);
    }
}
