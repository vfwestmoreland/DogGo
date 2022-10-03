using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Interfaces
{
    public interface IWalkerRepository
    {
        List<Walker> GetAllWalkers();

        List<Walker> GetWalkersInNeighborhood(int neighborhoodId);
        Walker GetWalkerById(int id);
    }
}
