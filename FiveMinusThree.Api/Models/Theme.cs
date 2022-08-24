namespace FiveMinusThree.Api.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //One-to-many realtionship
        public virtual List<Post> Posts { get; set; }
        
    }
}
