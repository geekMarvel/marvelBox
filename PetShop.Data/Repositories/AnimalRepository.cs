using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Models.Entities;

using System.Linq;

namespace PetShop.Data.Repositories
{
    public class AnimalRepository: IAnimalRepository
    {

        private PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context) 
        { 
            _context = context;
        }
        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
            return await _context.Animals.ToListAsync();
        }
        public async Task AddAnimalAsync(Animal animal)
        {
            await _context.Animals!.AddAsync(animal);
            await _context.SaveChangesAsync();
        }
        public Task<Animal> GetAnimalByIdAsync(int id)
        {
            //return await _context.Animals.SingleOrDefaultAsync(a => a.AnimalId == id);
            return Task.FromResult(_context.Animals!.Single(a => a.AnimalId == id));
        }
        public async Task UpdateAnimalAsync(Animal animal)
        {
            var animalInDb = await GetAnimalByIdAsync(animal.AnimalId);
            animalInDb.PhotoUrl = animal.PhotoUrl;
            animalInDb.Name = animal.Name;
            animalInDb.Lifespan = animal.Lifespan;
            animalInDb.Description = animal.Description;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAnimalAsync(int id)
        {
            var animalInDb = await GetAnimalByIdAsync(id);
            _context.Animals!.Remove(animalInDb);
            _context.SaveChanges();
        }
     
    }
}
