namespace PolymorphismApi.Models
{
    public class BaseClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public enum DerivedClassEnum
    {
        First,
        Second
    }
}
