using DogGo.Models;

namespace DogGo.Interfaces
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);

        Owner GetOwnerByEmail(string email);

        public void AddOwner(Owner owner);

        public void UpdateOwner(Owner owner);

        public void DeleteOwner(int ownerId);
    }
}
