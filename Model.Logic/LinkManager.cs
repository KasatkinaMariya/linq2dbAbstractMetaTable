using System;
using System.Collections.Generic;
using System.Linq;
using Db.Linq2dbImplementation;
using Db.Linq2dbImplementation.DataModels;
using Db.Linq2dbImplementation.Mapping;
using LinqToDB;
using Model.Interfaces;

namespace Model.Logic
{
    public class LinkManager
    {
        public void AddLink(LinkEntityBase link)
        {
            using (var db = new TestContext())
                db.InsertWithTableName(link);
        }

        public IEnumerable<LinkEntityBase> GetLinks(EntityType type)
        {
            var mapper = Factory.GetMapper(type);
            using (var db = new TestContext())
            {
                var query = mapper.GetLinkTable(db);
                return query.ToList();
            }
        }

        public IEnumerable<Guid> GetLinkedObjectIds(Entity entity)
        {
            var mapper = Factory.GetMapper(entity);
            using (var db = new TestContext())
            {
                var query = from link in mapper.GetLinkTable(db)
                    where link.EntityId == entity.Id
                    select link.LinkedObjectId;
                return query.ToList();
            }
        }

        public void RefreshLastAccessTimestamp(Entity entity, Guid linkedObjectId)
        {
            using (var db = new TestContext())
            {
                Factory.GetMapper(entity).GetLinkTable(db)
                    .Where(x => x.EntityId == entity.Id && x.LinkedObjectId == linkedObjectId)
                    .Set(x => x.LastAccessTimestamp, DateTimeOffset.Now)
                    .Update();
            }
        }
    }
}
