namespace FiveMinusThree.Api.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  virtual List<Post> Posts { get; set; }
        //Many-to-many realtionship
    }
}
