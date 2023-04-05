using iot.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace iot.Data.Repositories
{
    public class ItemsRepository: IItemsRepository
    {
        private readonly AppDbContext _appDbContext;
        public ItemsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Item>> GetAll() => await _appDbContext.Items.ToListAsync();
        public async Task Create(List<Item> items)
        {
            foreach(var item in items)
            {
                item.Id = Guid.NewGuid();
                item.Date = DateTime.Now;
                _appDbContext.AddAsync(item);
                _appDbContext.SaveChangesAsync();
            }
        }

    }
}
