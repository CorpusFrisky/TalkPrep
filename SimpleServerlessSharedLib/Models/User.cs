namespace SimpleServerlessSharedLib.Models
{
    public class User
    {
        public User(long id, string name, int streetNumber, string streetName)
        {
            Id = id;
            Name = name;
            StreetNumber = streetNumber;
            StreetName = streetName;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
    }
}
