using DogGo.Models;

namespace DogGo.Interfaces
{
    public interface INeighborhoodRepository
    {
        List<Neighborhood> GetAll();

        Neighborhood GetNeighborhoodById(int neighborhoodId);

        List<Neighborhood> GetNeighborhoodByOwnerId(int ownerId);
    }
}