namespace DataMatrix.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }

    public class UserPayload
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required int Phone { get; set; }
        public required string Email { get; set; }

    }
}
