using System;
using System.Collections.Generic;
using System.Linq;
using Db.Linq2dbImplementation.DataModels;
using Db.Linq2dbImplementation.Mapping;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Repositories
{
    public class SomeRelatedDataRepository : ISomeRelatedDataRepository
    {
        public void AddLink(Link link)
        {
            var mapper = Factory.GetMapper(link.Entity);
            var dbLink = mapper.FromModelToDb(link);

            using (var db = new TestContext())
                db.Insert(dbLink, mapper.TableName);
        }

        public IEnumerable<Guid> GetLinkedObjectIds(Entity entity)
        {
            using (var db = new TestContext())
            {
                var query = from link in Factory.GetMapper(entity).GetTable(db)
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
