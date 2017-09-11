using Db.Linq2dbImplementation.DataModels;
using LinqToDB;
using Model.Interfaces;

namespace Db.Linq2dbImplementation.Mapping
{
    class MapperA : MapperBase<some_data_entity_a>
    {
        public override EntityType Type { get; } = EntityType.TypeA;
        public override string TableName { get; } = "some_data_entity_a";
        public override ITable<some_data_entity_a> GetTable(TestContext db) => db.some_data_entity_a;

        public override some_data_entity_a FromModelToDb(Link link)
        {
            var dbLink = new some_data_entity_a();
            FillDbFromModel(link, dbLink);
            return dbLink;
        }
    }
}