using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    interface IMapper<out TDb> where TDb : some_data_entity_base
    {
        string TableName { get; }

        ITable<TDb> GetTable(TestContext db);
        TDb FromModelToDb(Link link);
    }
}