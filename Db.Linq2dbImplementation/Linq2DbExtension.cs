using LinqToDB;
using LinqToDB.Data;

namespace Db.Linq2dbImplementation
{
    public static class Linq2DbExtension
    {
        public static void InsertWithTableName<T>(this DataConnection db, T obj)
        {
            db.Insert(obj, obj.GetType().Name);
        }
    }
}
