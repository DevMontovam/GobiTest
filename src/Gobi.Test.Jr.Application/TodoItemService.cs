﻿using Gobi.Test.Jr.Domain;
using Gobi.Test.Jr.Domain.Interfaces;

namespace Gobi.Test.Jr.Application
{
	public class TodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItemRepository.GetAll();
        }
        public IReadOnlyList<TodoItem> GetOne(int id)
        {
            return _todoItemRepository.GetOne(id).ToList();
        }

        public void Add(TodoItem todoItem)
        {
            _todoItemRepository.Add(todoItem);
        }
        public void Edit(TodoItem todoItem)
        {
            _todoItemRepository.Edit(todoItem);
        }
        public void Delete(TodoItem todoItem)
        {
            _todoItemRepository.Delete(todoItem);
        }
    }
}