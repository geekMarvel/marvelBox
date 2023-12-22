using PetShop.Models.Entities;


namespace PetShop.Data.Repositories
{
    public interface IAnimalRepository
    {
        Task<Animal> GetAnimalByIdAsync(int id);
        Task<IEnumerable<Animal>> GetAllAnimalsAsync();
        Task AddAnimalAsync(Animal animal);
        Task UpdateAnimalAsync(Animal animal);
        Task DeleteAnimalAsync(int id);
    }
}
