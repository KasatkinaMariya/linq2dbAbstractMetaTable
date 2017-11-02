using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    public class MapperB : IMapper<LinkEntityB>
    {
        public EntityType Type { get; } = EntityType.TypeB;

        public string TableName { get; } = "LinkEntityB";
        public ITable<LinkEntityB> GetTable(TestContext db) => db.LinkEntityB;
    }
}