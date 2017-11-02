using System;
using System.Collections.Generic;
using System.Linq;
using Db.Linq2dbImplementation.DataModels;
using Db.Linq2dbImplementation.Mapping;
using LinqToDB;
using Model.Interfaces;

namespace Model.Logic
{
    public class SomeRelatedManager
    {
        public void AddLink(some_data_entity_base link)
        {
            var mapper = Factory.GetMapper(link.entity_type);
            using (var db = new TestContext())
                db.Insert(link, mapper.TableName);
        }

        public IEnumerable<some_data_entity_base> GetLinks(EntityType type)
        {
            var mapper = Factory.GetMapper(type);
            using (var db = new TestContext())
            {
                var query = mapper.GetTable(db);
                return query.ToList();
            }
        }

        public IEnumerable<Guid> GetLinkedObjectIds(Entity entity)
        {
            var mapper = Factory.GetMapper(entity);
            using (var db = new TestContext())
            {
                var query = from link in mapper.GetTable(db)
                    where link.entity_id == entity.Id
                    select link.linked_object_id;
                return query.ToList();
            }
        }

        public void RefreshLastAccessTimestamp(Entity entity, Guid linkedObjectId)
        {
            using (var db = new TestContext())
            {
                Factory.GetMapper(entity).GetTable(db)
                    .Where(x => x.entity_id == entity.Id && x.linked_object_id == linkedObjectId)
                    .Set(x => x.last_access_timestamp, DateTimeOffset.Now)
                    .Update();
            }
        }
    }
}
