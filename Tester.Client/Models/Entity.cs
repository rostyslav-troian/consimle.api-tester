using Tester.Client.Interfaces;

namespace Tester.Client.Models
{
    public abstract class Entity : IEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public abstract class Entity<T> : Entity
        where T : Entity
    {     
        public override bool Equals(object _obj)
        {
            var obj = _obj as T;
            return obj != null && Id == obj.Id;
        }
        public override int GetHashCode() => Id.GetHashCode() + Name.GetHashCode();
    }
}
