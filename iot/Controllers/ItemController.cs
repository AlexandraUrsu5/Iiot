using iot.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using iot.Data.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace iot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            var doctors = await _itemsRepository.GetAll();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] List<Item> items)
        {
            await _itemsRepository.Create(items);
            return Ok();
        }
    }
}