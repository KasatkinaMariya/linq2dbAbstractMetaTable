using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    abstract class MapperBase<TDb> : IMapper<TDb> where TDb : some_data_entity_base
    {
        public abstract string TableName { get; }

        public abstract ITable<TDb> GetTable(TestContext db);
        public abstract TDb FromModelToDb(Link link);

        protected void FillDbFromModel(Link link, TDb toFill)
        {
            toFill.entity_id = link.Entity.Id;
            toFill.linked_object_id = link.LinkedObjectId;
            toFill.last_access_timestamp = link.LastAccessTimestamp;
        }
    }
}