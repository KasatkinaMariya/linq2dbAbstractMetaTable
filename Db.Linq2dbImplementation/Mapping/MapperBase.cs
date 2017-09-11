using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    abstract class MapperBase<TDb> : IMapper<TDb> where TDb : some_data_entity_base
    {
        public abstract EntityType Type { get; }
        public abstract string TableName { get; }

        public abstract ITable<TDb> GetTable(TestContext db);
        public abstract TDb FromModelToDb(Link link);

        public Link FromDbToModel(some_data_entity_base dbLink)
        {
            if (dbLink == null)
                return null;

            return new Link
            {
                Entity = new Entity
                {
                    Id = dbLink.entity_id,
                    Type = Type,
                },
                LinkedObjectId = dbLink.linked_object_id,
                LastAccessTimestamp = dbLink.last_access_timestamp,
            };
        }

        protected void FillDbFromModel(Link link, TDb toFill)
        {
            toFill.entity_id = link.Entity.Id;
            toFill.linked_object_id = link.LinkedObjectId;
            toFill.last_access_timestamp = link.LastAccessTimestamp;
        }
    }
}