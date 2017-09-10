using System;
using LinqToDB.Mapping;

namespace Db.Linq2dbImplementation.DataModels
{
    public abstract class some_data_entity_base
    {
        [PrimaryKey, Identity] public int id { get; set; } // integer
        [Column, NotNull] public Guid entity_id { get; set; } // uuid
        [Column, NotNull] public Guid linked_object_id { get; set; } // uuid
        [Column, NotNull] public DateTimeOffset last_access_timestamp { get; set; } // timestamp (6) with time zone
    }
    public partial class some_data_entity_a : some_data_entity_base {}
    public partial class some_data_entity_b : some_data_entity_base {}
}
