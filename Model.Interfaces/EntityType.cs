using LinqToDB.Mapping;

namespace Model.Interfaces
{
    public enum EntityType
    {
        [MapValue(1)] TypeA,
        [MapValue(2)] TypeB,
    }
}