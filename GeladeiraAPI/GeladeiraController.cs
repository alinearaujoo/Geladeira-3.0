using System.Linq; //Para usar o Linq
using GeladeiraAPI.Domain; //Para usar o Domain
using Microsoft.AspNetCore.Mvc; //Para usar o Controller
using System.Collections.Generic; //Para usar o IEnumerable


namespace GeladeiraAPI.Controllers //Namespace da API
{
    [Route("api/[controller]")] 
    [ApiController]
    public class GeladeiraController : ControllerBase //Classe Controller
    {
        public readonly Geladeira geladeira; //Para usar o Geladeira

        public GeladeiraController() //Construtor
        {
            Geladeira _geladeira = Geladeira.CriarGeladeira(); //Cria uma geladeira
        }

        //RETORNA TODOS OS ITENS
        // GET: api/<GeladeiraController> 
        [HttpGet]
        public IActionResult GetAllItems() //Retorna todos os itens da geladeira
        {
            var items = geladeira.GetAllItems(); 
            return Ok(items); 
        }

        //RETORNA UM ITEM ESPECÍFICO MOSTRANDO O ANDAR E A POSIÇÃO
        // GET api/<GeladeiraController>/5 
        [HttpGet("{id}")]
        public IActionResult GetItemByID(int id) //Retorna um item pelo ID
        {
            var itemInfo = geladeira.GetItemById(id); //Pega o item pelo ID
            if (itemInfo == null) //Se o item não foi encontrado
            {
                return NotFound(); //Retorna o item inexistente
            }
            var (item, andar, container) = itemInfo.Value; //Pega o item, o andar e o container
            return Ok(new { Item = item, Andar = andar, Container = container }); //Retorna o item, o andar e o container
        }

        //INCLUI UM NOVO ITEM
        // POST api/<GeladeiraController> 
        [HttpPost]
        public IActionResult AddItem([FromBody] Item item, int andar, int container) //Adiciona um item na geladeira
        {
            geladeira.AddItem(item, andar, container); 
            return CreatedAtAction(nameof(GetItemByID), new { id = item.IdItem }, item); //Retorna o item criado
        }

        //ALTERA UM ITEM EM UMA POSIÇÃO
        // PUT api/<GeladeiraController>/5 
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item newItem) //Altera um item na geladeira
        {
            var itemInfo = geladeira.GetItemById(id); //Pega o item pelo ID
            if (itemInfo == null) //Se o item não foi encontrado
            {
                return NotFound(); //Retorna o item inexistente
            }

            geladeira.UpdateItem(id, newItem); //Altera o item na geladeira
            return NoContent(); //Retorna o item alterado
        }

        //EXCLUI UM ITEM DE UMA POSIÇÃO
        // DELETE api/<GeladeiraController>/5 
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id) //Exclui um item da geladeira
        {
            var itemInfo = geladeira.GetItemById(id); //Pega o item pelo ID
            if (itemInfo == null) //Se o item não foi encontrado
            {
                return NotFound(); //Retorna o item inexistente
            }

            geladeira.DeleteItem(id); //Exclui o item da geladeira
            return NoContent(); //Retorna o item excluído
        }
    }
}
