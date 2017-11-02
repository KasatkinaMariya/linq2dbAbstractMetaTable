using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    public interface IMapper<out TDb> where TDb : LinkEntityBase
    {
        EntityType Type { get; }

        string TableName { get; }
        ITable<TDb> GetTable(TestContext db);
    }
}