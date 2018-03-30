using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synergy.Scrambler.Common;
using Synergy.Scrambler.Model;
using Synergy.Scrambler.Model.Configuration;
using NUnit.Framework;
using Synergy.Scrambler.Engine;

namespace TestingClass
{
    [TestFixture]
    public class MsSqlBusinessLogicTest
    {
        [Test]
        public void ShouldTestConnection()
        {
            IScramblerEngine _scramblerEngine;

            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Data; Integrated Security = True ;";
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            var actualOut = _scramblerEngine.TestCon();
         
            Assert.AreEqual(false, actualOut);
            connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            actualOut = _scramblerEngine.TestCon();
            Assert.AreEqual(true, actualOut);

        }
        [Test]
        public void ShouldGetDataBases()
        {
            IScramblerEngine _scramblerEngine;

            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            var actualOut = _scramblerEngine.GetDatabases(connectionString);
            List<String> expectedOut = new List<string>();
            expectedOut.Add("master");
            expectedOut.Add("tempdb");
            expectedOut.Add("model");
            expectedOut.Add("msdb");
            expectedOut.Add("RoomDBContext");
            expectedOut.Add("LAB10.Models.StudentContext");
            expectedOut.Add("AdventureWorks2012");
            expectedOut.Add("AdventureWorks2012_CopyDB");
            expectedOut.Add("AdventureWorks2012_Copy");

            CollectionAssert.AreEqual(expectedOut,actualOut);

        }
        [Test]
        public void ShouldGetSchema()
        {
            IScramblerEngine _scramblerEngine;

            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = RoomDBContext; Integrated Security = True ;";
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            var actualOut = _scramblerEngine.FetchSchema();
           
            List<Columns> myColumns = new List<Columns>();
            List<String> names = new List<string>();
            Columns t1 = new Columns();
            Columns t2 = new Columns();
            Columns t3 = new Columns();
            t1.Name = "FloorID";
            myColumns.Add(t1);

            Table myTable = new Table();
            myTable.ColumnsList = myColumns;
            myTable.TableName ="[dbo].[Floor]";
            List<Table> tables = new List<Table>();
            tables.Add(myTable);
            CollectionAssert.AreEqual(tables, actualOut);

           
        }
        [Test]
        public void ShouldGetData()
        {
            IScramblerEngine _scramblerEngine;

            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = RoomDBContext; Integrated Security = True ;";
            String query = "Select * from [dbo].[Floor]";
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
              _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            var actualOut = _scramblerEngine.FetchData("[dbo].[Floor]", "FloorID", 1);

          
            List<String> id = new List<string>();
            id.Add("1 ") ;
          

        
            CollectionAssert.AreEqual(actualOut, id);


        }

        [Test]
        public void ShouldUpdateDB()
        {
            IScramblerEngine _scramblerEngine;

            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks; Integrated Security = True ;";
            String query = "insert into dbo.Messages values ('this is a message')";

          
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
           


            List<String> queries = new List<string>();
            queries.Add(query);
            var actualOut = _scramblerEngine.UpdateDataBase(queries);



            Assert.AreEqual(false, actualOut);


        }

        [Test]
        public void ShouldGetTotalCount()
        {
            IScramblerEngine _scramblerEngine;

            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";
          


            _scramblerEngine = new MsSqlBusinessLogic(connectionString);


;
            var actualOut = _scramblerEngine.FetchTotal("HumanResources.Department", "Name");



            Assert.AreEqual(16 ,actualOut);

          
        }
    }
}

