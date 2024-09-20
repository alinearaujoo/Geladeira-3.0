using GeladeiraAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(int id);
    Task AddItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(int id);
}
