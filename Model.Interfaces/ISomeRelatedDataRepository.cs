using System;
using System.Collections.Generic;

namespace Model.Interfaces
{
    public interface ISomeRelatedDataRepository
    {
        void AddLink(Link link);
        IEnumerable<Link> GetLinks(EntityType type);
        IEnumerable<Guid> GetLinkedObjectIds(Entity entity);

        void RefreshLastAccessTimestamp(Entity entity, Guid linkedObjectId);
    }
}