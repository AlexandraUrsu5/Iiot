using iot.Core.Entities;

namespace iot.Data.Repositories
{
    public interface IItemsRepository
    {
        public Task<IEnumerable<Item>> GetAll();
        public Task Create(List<Item> items);

    }
}
