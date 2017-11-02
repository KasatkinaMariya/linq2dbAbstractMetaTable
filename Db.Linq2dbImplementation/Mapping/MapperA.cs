using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    public class MapperA : IMapper<LinkEntityA>
    {
        public EntityType Type { get; } = EntityType.TypeA;

        public string TableName { get; } = "LinkEntityA";
        public ITable<LinkEntityA> GetTable(TestContext db) => db.LinkEntityA;
    }
}