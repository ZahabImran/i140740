using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Synergy.Scrambler.Model;
using System.Threading.Tasks;
using System.Threading;

namespace Synergy.Scrambler.Engine
{
    public class MsSqlBusinessLogic:IScramblerEngine
    {

        public List<Table> list = new List<Table>();
        public List<String> _db = new List<String>();

        public List<String> result = new List<String>();
        public Table myTable = new Table();
        SqlConnection cnn;
        SqlConnection cnn1;
        String _ConString;
        public MsSqlBusinessLogic(string connectionString)
        {
            _ConString = connectionString;
          // cnn = new SqlConnection(connectionString);
           // cnn1 = new SqlConnection(connectionString);



        }
        ~MsSqlBusinessLogic()
        {
          //  cnn.Close();
          //  cnn1.Close();
        }
   public Boolean TestCon()
        {
            
            using (SqlConnection cnn = new SqlConnection(_ConString))
            {
                try
                {
                    cnn.Open();
                    cnn.Close();
                    return true;
                }
                catch
                {
                    cnn.Close();

                    return false;
                }
            }
        }
        public List<String> GetDatabases(String ConnectionString)
        {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        cnn.Open();
                        var sqlCmd1 = cnn.CreateCommand();
                        sqlCmd1.CommandText = "SELECT * FROM sys.databases";  // No data wanted, only schema
                        sqlCmd1.CommandType = CommandType.Text;
                        using (SqlDataReader sqlDR1 = sqlCmd1.ExecuteReader())
                        {
                            while (sqlDR1.Read())
                            {
                                _db.Add(sqlDR1[0].ToString());
                            }
                            sqlDR1.Close();
                        }

                        cnn.Close();
                        return _db;


                    }
                    catch
                    {
                        cnn.Close();
                        return _db;


                    }
                }

            
          

        }
        public List<Table> FetchSchema()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_ConString))
                {
                    cnn.Open();
                    var sqlCmd1 = cnn.CreateCommand();
                    sqlCmd1.CommandText = "SELECT '['+SCHEMA_NAME(schema_id)+'].['+name+']'AS SchemaTable FROM sys.tables";  // No data wanted, only schema
                    sqlCmd1.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDR1 = sqlCmd1.ExecuteReader())
                    {
                        while (sqlDR1.Read())
                        {
                            Table table = new Table();

                            table.TableName = sqlDR1[0].ToString();
                            table.ColumnsList = FetchColumns(table.TableName);

                            list.Add(table);
                        }
                        sqlDR1.Close();
                    }
                    cnn.Close();
                }

            }
            catch (Exception ex)
            {
                //  cnn.Close();
                if (cnn!= null)
                {
                    cnn.Close();
                }

            }
            //    cnn.Close();

            return list;
        }


        public List<Columns> FetchColumns (String TableName)
            {
            List<Columns> CList = new List<Columns>();

            using (SqlConnection cnn1 = new SqlConnection(_ConString))
            {

                cnn1.Open();
            var result = new List<string>();
                try
                {

                    var sqlCmd = cnn1.CreateCommand();
                    sqlCmd.CommandText = "select * from " + TableName + " where 1=0";  // No data wanted, only schema
                    sqlCmd.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        var dataTable = sqlDR.GetSchemaTable();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            sqlDR.Close();
                            Columns Col = new Columns();
                            Col.Name = row.Field<string>("ColumnName");
                            //     Col.DataType = GetType(Col.Name, TableName);
                            CList.Add(Col);

                        }
                        sqlDR.Close();
                    }
                    cnn1.Close();

                }
                catch (Exception e)
                {
                    cnn1.Close();

                    Console.WriteLine(e);
                }
            }
          
         //   cnn1.Close();

            return CList;

        }

        public Boolean UpdateDataBase(List <String >  list)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_ConString))
                {
                    cnn.Open();

                    foreach (var qry in list)
                    {
                        string querystr = qry.ToString();
                        SqlCommand query = new SqlCommand(querystr, cnn);
                        try
                        {
                            query.ExecuteNonQuery();
                        }
                        catch(Exception e)
                        {
                            cnn.Close();

                            return false;
                        }
                    }
                    cnn.Close();

                    return true;

                }

            }
            catch (Exception ex)
            {
               

                    // cnn.Close();
                  //  cnn.Close();

                    return false;
                
            }
      //      cnn.Close();

        }

      public string GetType(string colName, string tableName)
        {
            string dataType;
            using (SqlConnection cnn = new SqlConnection(_ConString))
            {
                var sqlCmd = cnn.CreateCommand();

                sqlCmd.CommandText = "select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS IC where TABLE_NAME = '" + tableName + "'and COLUMN_NAME = '" + colName + "'";
                ;
                SqlDataReader reader = sqlCmd.ExecuteReader();
                reader.Read();
                dataType = reader[0].ToString();

                reader.Close();
            }
            return dataType;

        }
        
        public List<String> FetchData(String TableName,String ColName,int Rows)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_ConString))
                {
                    cnn.Open();
                    string query = "SELECT " + ColName + " FROM  " + TableName;

                    // Create a SqlCommand object and pass the constructor the connection string and the query string.
                    SqlCommand cmd = new SqlCommand(query, cnn);

                    // Use the above SqlCommand object to create a SqlDataReader object.
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (i < Rows)
                    {
                        rdr.Read();
                        String temp = "";

                        temp = temp + rdr[0].ToString() + " ";

                        result.Add(Convert.ToString(temp));
                        i++;
                        temp = "";
                    }
                    i = 0;
                    cnn.Close();
                }
            }
            catch (Exception e)
            {
                cnn.Close();
            }
            return result;

        }

        public int FetchTotal(String TableName, String ColName)
        {
            int temp=0;
            try
            {
                using (SqlConnection cnn = new SqlConnection(_ConString))
                {
                    cnn.Open();     
                string query = "SELECT Count(" + ColName + ") FROM  " + TableName;

                // Create a SqlCommand object and pass the constructor the connection string and the query string.
                SqlCommand cmd = new SqlCommand(query, cnn);

                // Use the above SqlCommand object to create a SqlDataReader object.
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   
                        temp = Convert.ToInt32(rdr[0]) ;
                    
                   
                }
                cnn.Close();
                    }
            }
            catch (Exception e)
            {
                cnn.Close();

            }
            return temp;
        }
        public void Processing( String Table)
        {

        }

    }
}
