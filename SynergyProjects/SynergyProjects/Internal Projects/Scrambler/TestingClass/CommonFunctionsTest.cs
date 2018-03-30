using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synergy.Scrambler.Common;
using Synergy.Scrambler.Model;
using Synergy.Scrambler.Model.Configuration;
using NUnit.Framework;
namespace TestingClass
{
    [TestFixture]
    public class CommonFunctionsTest
    {
        [Test]
        public void ShouldGetTableNames()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Table> myTable = new List<Table>();
            List<String> names = new List<string>();
            List<String> expectedOut = new List<String>();
            expectedOut.Add("Person");
            expectedOut.Add("Department");
            expectedOut.Add("Faculty");
            Table t1 = new Table();
            Table t2 = new Table();
            Table t3 = new Table();
            t1.TableName = "Person";
            myTable.Add(t1);
            t2.TableName = "Department";
            myTable.Add(t2);
            t3.TableName = "Faculty";
            myTable.Add(t3);
            names = cf.copyNames(names, myTable);

            CollectionAssert.AreEqual(expectedOut, names);
        }
        [Test]
        public void ShouldGetColumnNames()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Columns> myTable = new List<Columns>();
            List<String> names = new List<string>();
            List<String> expectedOut = new List<String>();
            expectedOut.Add("Person");
            expectedOut.Add("Department");
            expectedOut.Add("Faculty");
            Columns t1 = new Columns();
            Columns t2 = new Columns();
            Columns t3 = new Columns();
            t1.Name = "Person";
            myTable.Add(t1);
            t2.Name = "Department";
            myTable.Add(t2);
            t3.Name = "Faculty";
            myTable.Add(t3);
            names = cf.CopyNames(names, myTable);

            CollectionAssert.AreEqual(expectedOut, names);
        }
        [Test]
        public void ShouldGetColumnNamesAndMaskingCriteria()
        {
            CommonFunctions cf = new CommonFunctions();
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();
            List<String> actualOut = new List<string>();
            List<String> expectedOut = new List<string>();
            expectedOut.Add("Message --> ParagraphMask");
            IMappingConfig imc = new ParagraphMask();
            imc.StoreInObject("ParagraphMask", 3);

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            actualOut = cf.CopyNames(actualOut, myTable);
            CollectionAssert.AreEqual(expectedOut, actualOut);
        }
        [Test]
        public void ShouldGetColumnTypes()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Columns> myTable = new List<Columns>();
            List<String> names = new List<string>();
            List<String> expectedOut = new List<String>();
            expectedOut.Add("int");
            expectedOut.Add("string");
            expectedOut.Add("date");
            Columns t1 = new Columns();
            Columns t2 = new Columns();
            Columns t3 = new Columns();
            t1.DataType = "int";
            myTable.Add(t1);
            t2.DataType = "string";
            myTable.Add(t2);
            t3.Name = "date";
            myTable.Add(t3);
            names = cf.CopyTypes(names, myTable);

            CollectionAssert.AreEqual(expectedOut, names);
        }
        [Test]
        public void ShouldSaveProjectConfig()
        {
            CommonFunctions cf = new CommonFunctions();
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();
            int actualOut;
            List<String> expectedOut = new List<string>();
            expectedOut.Add("Message --> ParagraphMask");
            IMappingConfig imc = new ParagraphMask();
            imc.StoreInObject("ParagraphMask", 3);

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            actualOut = cf.SaveConfig(PC, @"C:\Users\My Book\Desktop\TestingFuncSaveConfig");
            Assert.AreEqual(1, actualOut);
        }

        [Test]
        public void ShouldSaveTableConfig()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Table> myTable = new List<Table>();
            List<String> names = new List<string>();
            int actualOut;
            Table t1 = new Table();
            Table t2 = new Table();
            Table t3 = new Table();
            t1.TableName = "Person";
            myTable.Add(t1);
            t2.TableName = "Department";
            myTable.Add(t2);
            t3.TableName = "Faculty";
            myTable.Add(t3);
            actualOut = cf.SaveConfig(myTable, @"C:\Users\My Book\Desktop\TestingFuncSaveConfig");

            Assert.AreEqual(1, actualOut);
        }

        [Test]
        public void ShouldSaveStringLists()
        {
            CommonFunctions cf = new CommonFunctions();

            List<String> input1 = new List<String>();
            input1.Add("int");
            input1.Add("string");
            input1.Add("date");
            List<String> input2 = new List<String>();
            input2.Add("int");
            input2.Add("string");
            input2.Add("date");

            int actualOut;

            actualOut = cf.SaveStringData(input1, input2);

            Assert.AreEqual(1, actualOut);
        }
        [Test]
        public void ShouldSaveStringListsMask()
        {
            CommonFunctions cf = new CommonFunctions();

            List<String> input1 = new List<String>();
            input1.Add("int");
            input1.Add("string");
            input1.Add("date");
            List<String> input2 = new List<String>();
            input2.Add("int");
            input2.Add("string");
            input2.Add("date");

            int actualOut;

            actualOut = cf.SaveStringDataMask(input1, input2);

            Assert.AreEqual(1, actualOut);
        }
        [Test]
        public void ShouldGetProjectConfig()
        {
            CommonFunctions cf = new CommonFunctions();
            TableCofig myTable = new TableCofig();
            ColumnConfig myColumn = new ColumnConfig();

            List<String> expectedOut = new List<string>();
            expectedOut.Add("Message --> ParagraphMask");
            IMappingConfig imc = new ParagraphMask();
            imc.StoreInObject("ParagraphMask", 3);

            myColumn.MappingConfig = imc;
            myColumn.Name = "Message";
            myTable.ColumnConfigs.Add(myColumn);
            ProjectConfig PC = new ProjectConfig();
            PC.TableConfigs.Add(myTable);
            cf.SaveConfig(PC, @"C:\Users\My Book\Desktop\TestingFuncSaveConfig");



            var actualOut = cf.GetConfig(@"C:\Users\My Book\Desktop\TestingFuncSaveConfig");

            Assert.AreEqual(true, actualOut.Equals(PC));
        }
        [Test]
        public void ShouldSaveStringData()
        {
            CommonFunctions cf = new CommonFunctions();

            List<String> input1 = new List<String>();
            input1.Add("int");
            input1.Add("string");
            input1.Add("date");

            int actualOut;

            actualOut = cf.SaveStringData(input1);

            Assert.AreEqual(1, actualOut);
        }
        [Test]
        public void ShouldSplitLists()
        {
            CommonFunctions cf = new CommonFunctions();
            List<List<String>> inputs = new List<List<string>>();
            List<String> input1 = new List<String>();
            List<String> input2 = new List<String>();
            List<String> input3 = new List<String>();
            List<String> actualInput = new List<string>();
            actualInput.Add("int");
            actualInput.Add("string");
            actualInput.Add("date");
            input1.Add("int");
            input2.Add("string");
            input3.Add("date");
            inputs.Add(input1);
            inputs.Add(input2);
            inputs.Add(input3);




            var actualOut = cf.splitList(actualInput, 1);

            CollectionAssert.AreEqual(actualOut, inputs);
        }
        [Test]
        public void ShouldReturnRightCharacter()
        {
            CommonFunctions cf = new CommonFunctions();
            Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '!', '?', '-', '_', '@', '$', '#', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Char c = cf.CharacterGenerator('*');
            Assert.That(new char[] { c }, Is.SubsetOf(arr));

            Char[] arr1 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Char c1 = cf.CharacterGenerator('A');
            Assert.That(new char[] { c1 }, Is.SubsetOf(arr1));

            Char[] arr2 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            Char c2 = cf.CharacterGenerator('c');
            Assert.That(new char[] { c2 }, Is.SubsetOf(arr2));

            Char[] arr3 = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Char c3 = cf.CharacterGenerator('C');
            Assert.That(new char[] { c3 }, Is.SubsetOf(arr3));

            Char[] arr4 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Char c4 = cf.CharacterGenerator('d');
            Assert.That(new char[] { c4 }, Is.SubsetOf(arr4));

            Char[] arr5 = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Char c5 = cf.CharacterGenerator('D');
            Assert.That(new char[] { c5 }, Is.SubsetOf(arr5));

            Char[] arr6 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            Char c6 = cf.CharacterGenerator('X');
            Assert.That(new char[] { c6 }, Is.SubsetOf(arr6));

            Char[] arr7 = { '0', '1' };
            Char c7 = cf.CharacterGenerator('b');
            Assert.That(new char[] { c7 }, Is.SubsetOf(arr7));

            char check = 'z';
            char c8 = cf.CharacterGenerator(check);
            Assert.AreEqual(c8, check);





        }
        [Test]
        public void ShouldCheckForGender()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Table> tables = new List<Table>();
            Table myTable = new Table();
            myTable.TableName = "Emp";
            Columns myColumn = new Columns();
            
            myColumn.Name = "Gender";
            myTable.ColumnsList.Add(myColumn);

            tables.Add(myTable);
            var actualOut = cf.CheckGender(tables, "Emp");
            Assert.AreEqual(true, actualOut);
             actualOut = cf.CheckGender(tables, "Slate");
            Assert.AreEqual(false, actualOut);
        }
        [Test]
        public void ShouldCheckForCode()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Table> tables = new List<Table>();
            Table myTable = new Table();
            myTable.TableName = "Emp";
            Columns myColumn = new Columns();

            myColumn.Name = "Code";
            myTable.ColumnsList.Add(myColumn);

            tables.Add(myTable);
            var actualOut = cf.CheckCode(tables, "Emp");
            Assert.AreEqual(true, actualOut);
            actualOut = cf.CheckCode(tables, "Slate");
         Assert.AreEqual(false, actualOut);
        }

        [Test]
        public void ShouldCheckForHireDate()
        {
            CommonFunctions cf = new CommonFunctions();
            List<Table> tables = new List<Table>();
            Table myTable = new Table();
            myTable.TableName = "Emp";
            Columns myColumn = new Columns();

            myColumn.Name = "HireDate";
            myTable.ColumnsList.Add(myColumn);

            tables.Add(myTable);
            var actualOut = cf.CheckHireDate(tables, "Emp");
            Assert.AreEqual(true, actualOut);
            actualOut = cf.CheckHireDate(tables, "Slate");
            Assert.AreEqual(false, actualOut);
        }
        [Test]
        public void ShouldCheckForSensitivity()
        {
            CommonFunctions cf = new CommonFunctions();
            String input1 = "date";
            String input2 = "hiredate";

            var actualOut = cf.sensitivityTest(input1,input2);
            Assert.AreEqual(true, actualOut);
          }

        [Test]
        public void ShouldFetchRules()
        {
            CommonFunctions cf = new CommonFunctions();
            List<String> input1 = new List<string>();
            List<String> input2 = new List<string>();
            var actualOut = cf.fetchRules(input1, input2);
            Assert.AreEqual(true, actualOut);
        }
    }


}

