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
        public void AddLink(LinkEntityBase link)
        {
            var mapper = Factory.GetMapper(link.EntityType);
            using (var db = new TestContext())
                db.Insert(link, mapper.TableName);
        }

        public IEnumerable<LinkEntityBase> GetLinks(EntityType type)
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
                    where link.EntityId == entity.Id
                    select link.LinkedObjectId;
                return query.ToList();
            }
        }

        public void RefreshLastAccessTimestamp(Entity entity, Guid linkedObjectId)
        {
            using (var db = new TestContext())
            {
                Factory.GetMapper(entity).GetTable(db)
                    .Where(x => x.EntityId == entity.Id && x.LinkedObjectId == linkedObjectId)
                    .Set(x => x.LastAccessTimestamp, DateTimeOffset.Now)
                    .Update();
            }
        }
    }
}
