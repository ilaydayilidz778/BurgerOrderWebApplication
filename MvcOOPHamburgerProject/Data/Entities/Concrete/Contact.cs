namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; } // Mailin Oluşturulma Tarihi

        public double Latitude { get; set; } 
        public double Longitude { get; set; }

        // Adres bilgileri
        public Address Address { get; set; } = null!;
    
        public string? Emal { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
    }
}
