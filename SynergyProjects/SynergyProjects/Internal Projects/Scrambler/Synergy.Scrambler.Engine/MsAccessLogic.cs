using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using Synergy.Scrambler.Model;
using Synergy.Scrambler.Model.Configuration;

namespace Synergy.Scrambler.Engine
{
    public class MsAccessBusinessLogic : IScramblerEngine
    {
        private string _connectionString;
        public string _copydb = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/Users/zahab.imran/Desktop/CopyDB.mdb;persist security info = false;";
        List<String> result = new List<string>();
        public object ADODB { get; private set; }

        public MsAccessBusinessLogic()
        {

        }

        public MsAccessBusinessLogic(string connectionString)
        {
            _connectionString = connectionString;
        }

        //string connectionString = ;

         public Boolean TestCon()
        {
            return false;
        }
        public List<Table> FetchSchema()
        {
            var list = new List<Table>();
            var conn = new OleDbConnection(_connectionString);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();

                dt = conn.GetSchema("Tables");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Table table = new Table();
                    table.TableName = dt.Rows[i][2].ToString();
                    list.Add(table);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].ColumnsList = FetchColumns(list[i].TableName);
                }

            }
            catch (Exception ex)
            {

            }
            conn.Close();

            return list;
        }

        public List<Columns> FetchColumns(String TableName)
        {
            List<Columns> CList = new List<Columns>();

            var list = new List<Table>();
            var conn = new OleDbConnection(_connectionString);
            conn.Open();
            try
            {
                using (var cmd = new OleDbCommand("select * from " + TableName, conn))
                {

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        var table = reader.GetSchemaTable();
                        var nameCol = table.Columns["ColumnName"];
                        int i = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            Columns Col = new Columns();
                            Col.Name = row[nameCol].ToString();
                            System.Type type = reader.GetFieldType(i);
                            i++;
                            Col.DataType = type.Name;
                            CList.Add(Col);
                        }


                        reader.Close();

                    }
                }
            }
            catch (Exception e)
            {


            }
            return CList;

        }
        public string GetType(string colName, string tableName)
        {
            string dataType;




            return colName;
        }
        public List<String> FetchData(String TableName, String ColName, int Rows)
        {
            var conn = new OleDbConnection(_connectionString);
            conn.Open();
            OleDbDataReader rdr = null;
            var cmd = new OleDbCommand("select* from " + TableName, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                String temp = "";
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    temp = temp + rdr[i] + " ";
                }
                result.Add(Convert.ToString(temp));
                temp = "";
            }

            conn.Close();
            return result;
        }

        public void Processing(String Table)
        {
            string conString = (_copydb);
            OleDbConnection dbconn = new OleDbConnection(conString);
            dbconn.Open();
            OleDbCommand dbcommand = new OleDbCommand();


            string selQuery = "insert into [" + Table + "]select* from [MS Access; DATABASE = C:/Users/zahab.imran/Desktop/Database1.mdb].[C:/Users/zahab.imran/Desktop/CopyDB.mdb]";

            dbcommand.CommandText = selQuery;
            dbcommand.CommandType = CommandType.Text;
            dbcommand.Connection = dbconn;
            int result = dbcommand.ExecuteNonQuery();


            dbconn.Close();
        }

        public int FetchTotal(string TableName, string ColName)
        {
            var conn = new OleDbConnection(_connectionString);
            conn.Open();
            OleDbDataReader rdr = null;
            var cmd = new OleDbCommand("select COUNT(*) from " + TableName, conn);
            rdr = cmd.ExecuteReader();
            int temp = 0;
            while (rdr.Read())
            {

                temp = Convert.ToInt32(rdr[0]);

                result.Add(Convert.ToString(temp));
            }

            conn.Close();
            return temp;
        }

        public void UpdateDataBase(ProjectConfig PC, List<string> Actual, List<string> Scrambled)
        {
            throw new NotImplementedException();
        }

        public void UpdateDataBase(string TableName, string ColName, string Actual, string Scrambled)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateDataBase(List<string> list)
        {
            throw new NotImplementedException();
        }
        List<String> GetDatabases(String ConnectionString)
        {
            throw new NotImplementedException();

        }

        List<string> IScramblerEngine.GetDatabases(string ConnectionString)
        {
            throw new NotImplementedException();
        }
    }
}
