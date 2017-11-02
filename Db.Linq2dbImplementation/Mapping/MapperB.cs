using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    public class MapperB : IMapper<some_data_entity_b>
    {
        public EntityType Type { get; } = EntityType.TypeB;

        public string TableName { get; } = "some_data_entity_b";
        public ITable<some_data_entity_b> GetTable(TestContext db) => db.some_data_entity_b;
    }
}