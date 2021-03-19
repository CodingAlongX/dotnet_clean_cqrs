using Core.Entities.Base;

namespace Core.Entities
{
    public class Movie : Entity
    {
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string ReleaseYear { get; set; }
    }
}