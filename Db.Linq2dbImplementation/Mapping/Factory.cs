using System;
using Db.Linq2dbImplementation.DataModels;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    class Factory
    {
        public static IMapper<some_data_entity_base> GetMapper(Entity entity) => GetMapper(entity.Type);
        public static IMapper<some_data_entity_base> GetMapper(EntityType type)
        {
            if (type == EntityType.TypeA)
                return new MapperA();
            if (type == EntityType.TypeB)
                return new MapperB();
            throw new ArgumentException($"No mapping for entityType='{type}'");
        }
    }
}
