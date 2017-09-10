using System;

namespace Model.Interfaces
{
    public class Link
    {
        public Entity Entity { get; set; }
        public Guid LinkedObjectId { get; set; }
        public DateTimeOffset LastAccessTimestamp { get; set; }
    }
}