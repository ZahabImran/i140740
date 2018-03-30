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
    public class SqlJobsTest
    {

        [Test]
        public void ShouldGetScrambledConfig()
        {
            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";

            SqlScramblingJobs ssj = new SqlScramblingJobs(connectionString);
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();
           
           
            IMappingConfig imc = new Scramble();
            imc.StoreInObject("Data Scramble", 3);

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            var actualOut = ssj.GetScrambledConfig(PC);
           
            Assert.AreEqual(PC.ConnectionString, actualOut.ConnectionString);
        }

        [Test]
        public void ShouldGetMaskingConfig()
        {
            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";

            SqlScramblingJobs ssj = new SqlScramblingJobs(connectionString);
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();


            IMappingConfig imc = new DataMask();
            imc.StoreInObject("Data Mask", 3,3,"c");

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            var actualOut = ssj.GetMaskingConfig(PC);
            Assert.AreEqual(actualOut.ConnectionString, PC.ConnectionString);
        }
        [Test]
        public void ShouldGetParagraphConfig()
        {
            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";

            SqlScramblingJobs ssj = new SqlScramblingJobs(connectionString);
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();


            IMappingConfig imc = new ParagraphMask();
            imc.StoreInObject("ParagraphMask", 3);

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            var actualOut = ssj.GetParagraphConfig(PC);
            Assert.AreEqual(actualOut.ConnectionString, PC.ConnectionString);
        }
        [Test]
        public void ShouldGetReplaceConfig()
        {
            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";

            SqlScramblingJobs ssj = new SqlScramblingJobs(connectionString);
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();


            IMappingConfig imc = new ReplaceDS();
            imc.StoreInObject("Data Replacement", "names");

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            var actualOut = ssj.GetReplaceConfig(PC);
            Assert.AreEqual(actualOut.ConnectionString, PC.ConnectionString);
        }
        [Test]
        public void ShouldGetHashConfig()
        {
            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";

            SqlScramblingJobs ssj = new SqlScramblingJobs(connectionString);
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();


            IMappingConfig imc = new Hashing();
            imc.StoreInObject("Data Mask", 3, 3, "c");

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            var actualOut = ssj.GetMaskingConfig(PC);
            Assert.AreEqual(actualOut.ConnectionString, PC.ConnectionString);
        }
        [Test]
        public void ShouldTestConfig()
        {
            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012; Integrated Security = True ;";

            SqlScramblingJobs ssj = new SqlScramblingJobs(connectionString);
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();


            IMappingConfig imc = new Hashing();
            imc.StoreInObject("Data Mask", 3, 3, "c");

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            myTable.TableName = "[dbo].[Messages]";
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            var actualOut = ssj.ValidateConfig(PC);
            Assert.AreEqual(true, actualOut);
        }
    }
}
