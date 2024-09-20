using GeladeiraAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeladeiraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeladeiraController : ControllerBase
    {
        private readonly IItemService _itemService;

        public GeladeiraController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Item item)
        {
            await _itemService.AddItemAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdItem }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Item item)
        {
            if (id != item.IdItem)
            {
                return BadRequest();
            }

            await _itemService.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _itemService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}

