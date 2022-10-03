namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int NeighborhoodId { get; set; }

        public List<Neighborhood> Neighborhoods { get; set; }
        public string Phone { get; set; }


    }
}
