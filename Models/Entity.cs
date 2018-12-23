using System;

namespace API.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public DateTime Criacao { get; private set; }
        public DateTime Alteracao { get; private set; }
    }
}
