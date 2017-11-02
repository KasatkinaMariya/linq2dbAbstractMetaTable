using System;
using LinqToDB.Mapping;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.DataModels
{
    public abstract class LinkEntityBase
    {
        [PrimaryKey, Identity] public int Id { get; set; } // integer
        [Column, NotNull] public Guid EntityId { get; set; } // uuid
        [Column, NotNull] public Guid LinkedObjectId { get; set; } // uuid
        [Column, NotNull] public DateTimeOffset LastAccessTimestamp { get; set; } // timestamp (6) with time zone
        [Column, NotNull] public EntityType EntityType { get; set; } // smallint
    }

    public partial class LinkEntityA : LinkEntityBase
    {
        public LinkEntityA()
        {
            EntityType = EntityType.TypeA;
        }
    }

    public partial class LinkEntityB : LinkEntityBase
    {
        public LinkEntityB()
        {
            EntityType = EntityType.TypeB;
        }
    }
}
