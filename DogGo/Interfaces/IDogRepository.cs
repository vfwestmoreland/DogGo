using DogGo.Models;

namespace DogGo.Interfaces
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();

        List<Dog> GetDogsByOwnerId(int ownerId);
        Dog GetDogById(int id);

        public void AddDog(Dog dog);

        public void UpdateDog(Dog dog);    

        public void DeleteDog(int dogId);

    }
}
