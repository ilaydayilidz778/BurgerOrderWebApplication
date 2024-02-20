namespace MvcOOPHamburgerProject.Data.Entities.Concrete
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
