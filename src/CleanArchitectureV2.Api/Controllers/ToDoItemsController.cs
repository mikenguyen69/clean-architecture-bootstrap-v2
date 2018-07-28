using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CleanArchitectureV2.Core.Interfaces;
using CleanArchitectureV2.Core.Entities;
using CleanArchitectureV2.Api.DTO;
using CleanArchitectureV2.Api.Filters;

namespace CASportStore.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class ToDoItemsController : Controller
    {
        private readonly IRepository<ToDoItem> _todoRepository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IRepository<ToDoItem> todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {
            var items = _todoRepository.List()
                            .Select(item => _mapper.Map<ToDoItem, ToDoItemDTO>(item));
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _mapper.Map<ToDoItem, ToDoItemDTO>(_todoRepository.GetById(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public IActionResult Post([FromBody] ToDoItemDTO item)
        {
            var todoItem = new ToDoItem()
            {
                Title = item.Title,
                Description = item.Description
            };

            if (item.Id > 0)
            {
                todoItem.Id = item.Id;
            }

            _todoRepository.Add(todoItem);
            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(todoItem));
        }

        [HttpGet("{id:int}/complete")]
        public IActionResult Complete(int id)
        {
            var toDoItem = _todoRepository.GetById(id);
            toDoItem.MarkComplete();
            _todoRepository.Update(toDoItem);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(toDoItem));
        }

        [HttpPatch("complete")]
        public IActionResult Complete([FromBody] ToDoItemDTO itemDTO)
        {
            var item = _mapper.Map<ToDoItemDTO, ToDoItem>(itemDTO);
            item.MarkComplete();
            _todoRepository.Update(item);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(item));
        }
    }
}
