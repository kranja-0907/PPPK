using PPPK.Model;
using System.Data;

namespace PPPK.DAL
{
    interface IRepository
    {
        DataSet CreateDataSet(DBEntity entity);
        System.Collections.Generic.IEnumerable<Column> GetColumns(DBEntity dBEntity);
        System.Collections.Generic.IEnumerable<Database> GetDatabases();
        System.Collections.Generic.IEnumerable<DBEntity> GetEntities(Database database, DBEntityType entity);
        System.Collections.Generic.IEnumerable<Procedure> GetProcedures(Database database);
        System.Collections.Generic.IEnumerable<Parameter> GetParameters(Procedure procedure);
        void LogIn(string server, string username, string password);
        void DropDatabase(Database database);
        void UseDatabase(DBEntity dBEntity);
        DataSet CreateDataSetSQL(string SQL);
    }
}