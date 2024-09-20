using GeladeiraAPI.Domain;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _repository.GetAllItemsAsync();
    }

    public async Task<Item> GetItemByIdAsync(int id)
    {
        return await _repository.GetItemByIdAsync(id);
    }

    public async Task AddItemAsync(Item item)
    {
        await _repository.AddItemAsync(item);
    }

    public async Task UpdateItemAsync(Item item)
    {
        await _repository.UpdateItemAsync(item);
    }

    public async Task DeleteItemAsync(int id)
    {
        await _repository.DeleteItemAsync(id);
    }
}
