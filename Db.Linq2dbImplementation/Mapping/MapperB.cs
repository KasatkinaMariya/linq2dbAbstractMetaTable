using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    class MapperB : MapperBase<some_data_entity_b>
    {
        public override EntityType Type { get; } = EntityType.TypeB;
        public override string TableName { get; } = "some_data_entity_b";
        public override ITable<some_data_entity_b> GetTable(TestContext db) => db.some_data_entity_b;

        public override some_data_entity_b FromModelToDb(Link link)
        {
            var dbLink = new some_data_entity_b();
            FillDbFromModel(link, dbLink);
            return dbLink;
        }
    }
}