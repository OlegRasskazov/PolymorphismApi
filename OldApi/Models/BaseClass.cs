using System.Runtime.Serialization;

namespace OldApi.Models
{
    [KnownType(typeof(FirstSubClass))]
    [KnownType(typeof(SecondSubClass))]
    public class BaseClass
    {
        public BaseClass(string type) 
        {
            Type= type;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
