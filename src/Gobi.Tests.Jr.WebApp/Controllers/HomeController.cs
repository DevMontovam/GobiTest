using Gobi.Test.Jr.Application;
using Gobi.Test.Jr.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Gobi.Tests.Jr.WebApp.Controllers
{
	public class TodoController : Controller
    {
        private readonly TodoItemService _todoItemService;

        public TodoController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public IActionResult Index()
        {
            var items = _todoItemService.GetAll();
                        
            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new TodoItem());
        }

        [HttpPost]
        public IActionResult Add(TodoItem todoItem)
        {
            _todoItemService.Add(todoItem);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var registro = _todoItemService.GetOne(id).FirstOrDefault(gm => gm.Id == id);

            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }
        [HttpPost]
        public IActionResult Edit(int id, TodoItem todoItem)
        {
            var registroAntigo = _todoItemService.GetOne(id).FirstOrDefault(gm => gm.Id == id);

            if (registroAntigo == null)
            {
                return NotFound();
            }

            registroAntigo.Completed = todoItem.Completed;
            registroAntigo.Description = todoItem.Description;

            _todoItemService.Edit(registroAntigo);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(TodoItem todoItem)
        {
            _todoItemService.Delete(todoItem);

            return RedirectToAction("Index", todoItem);
        }
    }
}