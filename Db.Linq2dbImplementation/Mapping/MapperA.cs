using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    public class MapperA : IMapper<some_data_entity_a>
    {
        public EntityType Type { get; } = EntityType.TypeA;

        public string TableName { get; } = "some_data_entity_a";
        public ITable<some_data_entity_a> GetTable(TestContext db) => db.some_data_entity_a;
    }
}