using PPPK.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK.DAL
{
    class Repository : IRepository
    {
        private string cs;

        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name from sys.databases";
        private const string SelectTables = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.TABLES";
        private const string SelectViews = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.VIEWS";
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";

        private const string DropADatabase = "DROP DATABASE {0}";
        private const string UseADatabase = "USE {0}";

        public void LogIn(string server, string username, string password)
        {
            using (SqlConnection con = new SqlConnection(
                string.Format(ConnectionString, server, username, password)))
            {
                cs = con.ConnectionString;
                con.Open();
            }
        }

        void IRepository.UseDatabase(DBEntity dBEntity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(UseADatabase, dBEntity.Database.Name);
                    //cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                    }
                }
            }
        }

        public DataSet CreateDataSetSQL(string SQL)
        {
            //open close automatik
            using (SqlConnection con = new SqlConnection(cs))
            {
                //Represents a set of data commands and a database connection that are used to fill the DataSet and update a SQL Server database.
                //This class cannot be inherite
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = SQL;
                da.SelectCommand = cmd;

                //skup podataka tj lokalni database
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CreateDataSet(DBEntity entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                DataSet ds = new DataSet(entity.Name);
                SqlDataAdapter da = new SqlDataAdapter(string.Format(SelectQuery, entity.Database, entity.Schema, entity.Name), con);
                da.Fill(ds);
                ds.Tables[0].TableName = entity.Name;
                return ds;
            }
        }

        public IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = SelectDatabases;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Database
                            {
                                Name = dr[nameof(Database.Name)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<DBEntity> GetEntities(Database database, DBEntityType entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    switch (entity)
                    {
                        case DBEntityType.Table:
                            cmd.CommandText = string.Format(SelectTables, database.Name);
                            break;
                        case DBEntityType.View:
                            cmd.CommandText = string.Format(SelectViews, database.Name);
                            break;
                    }
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new DBEntity
                            {
                                Name = dr[nameof(DBEntity.Name)].ToString(),
                                Schema = dr[nameof(DBEntity.Schema)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }



        public IEnumerable<Procedure> GetProcedures(Database database)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectProcedures, database.Name);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Procedure
                            {
                                Name = dr[nameof(Procedure.Name)].ToString(),
                                Definition = dr[nameof(Procedure.Definition)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Parameter> GetParameters(Procedure procedure)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectProcedureParameters, procedure.Database.Name, procedure.Name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Parameter
                            {
                                Name = dr[nameof(Parameter.Name)].ToString(),
                                Mode = dr[nameof(Parameter.Mode)].ToString(),
                                DataType = dr[nameof(Parameter.DataType)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Column> GetColumns(DBEntity dBEntity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectColumns, dBEntity.Database.Name, dBEntity.Name);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Column
                            {
                                Name = dr[nameof(Column.Name)].ToString(),
                                DataType = dr[nameof(Column.DataType)].ToString(),
                            };
                        }
                    }
                }
            }
        }



        public void DropDatabase(Database database)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(DropADatabase, database.Name);
                    //cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                    }
                }
            }
        }


    }

}
