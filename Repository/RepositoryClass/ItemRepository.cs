using GeladeiraAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ItemRepository : IItemRepository
{
    private readonly GeladeiraContext _context;

    public ItemRepository(GeladeiraContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _context.Itens.ToListAsync();
    }

    public async Task<Item> GetItemByIdAsync(int id)
    {
        return await _context.Itens.FindAsync(id);
    }

    public async Task AddItemAsync(Item item)
    {
        await _context.Itens.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(Item item)
    {
        _context.Itens.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id)
    {
        var item = await _context.Itens.FindAsync(id);
        if (item != null)
        {
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
