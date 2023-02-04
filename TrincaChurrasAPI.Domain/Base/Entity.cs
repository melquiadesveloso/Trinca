using TrincaChurrasAPI.Domain.Interfaces;

namespace TrincaChurrasAPI.Domain.Base
{
    public abstract class Entity : IEntity
    {
        public string id { get; set; }

        protected Entity()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}