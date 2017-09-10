using System;

namespace Model.Interfaces
{
    public class Entity
    {
        public Guid Id { get; set; }
        public EntityType Type { get; set; }
    }
}