using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Synergy.Scrambler.Model;
using Synergy.Scrambler.Model.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
namespace Synergy.Scrambler.Common
{
    public class CommonFunctions
    {

        public List<string> copyNames(List<String> names, List<Table> myTables)
        {
            for (int i = 0; i < myTables.Count; i++)
            {
                names.Add(myTables[i].TableName);

            }

            return names;
        }

        public List<string> CopyNames(List<String> names, List<Columns> myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
            {
                names.Add(myCol[i].Name);

            }

            return names;
        }
        public List<string> CopyNames(List<String> names, TableCofig table)
        {
            for (int i = 0; i < table.ColumnConfigs.Count; i++)
            {
                names.Add(table.ColumnConfigs[i].Name + " --> " + table.ColumnConfigs[i].MappingConfig.Name);

            }

            return names;
        }

        public List<string> CopyTypes(List<String> names, List<Columns> myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
            {
                names.Add(myCol[i].DataType);

            }

            return names;
        }
     
        public int SaveConfig(ProjectConfig PC, String Filename)
        {
            if (PC == null) { return 0; }
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            String path = String.Concat(Filename.ToString());
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, PC);
            }
            return 1;

        }
        public int SaveConfig(List<Table> PC, String Filename)
        {
            if (PC == null) { return 0; }
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            String path = String.Concat(Filename.ToString());
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, PC);
            }
            return 1;

        }
     
        public int SaveStringData(List<String> Actual, List<String> Tampered)
        {
            if (Actual == null) { return 0; }
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            String path = String.Concat(@"C:\Users\My Book\Desktop\Actual.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Actual);
            }


            if (Tampered == null) { return 0; }
            serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            path = String.Concat(@"C:\Users\My Book\Desktop\Tampered.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Tampered);
            }
            return 1;

        }
        public int SaveStringDataMask(List<String> Actual, List<String> Tampered)
        {
            if (Actual == null) { return 0; }
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            String path = String.Concat(@"C:\Users\My Book\Desktop\ActualMask.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Actual);
            }


            if (Tampered == null) { return 0; }
            serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            path = String.Concat(@"C:\Users\My Book\Desktop\TamperedMask.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Tampered);
            }
            return 1;

        }
        public ProjectConfig GetConfig(String Filename)
        {


            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(Filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                ProjectConfig PC = (ProjectConfig)serializer.Deserialize(file, typeof(ProjectConfig));
                return PC;
            }



        }
        public List<Table> GetConfigs(String Filename)
        {


            // deserialize JSON directly from a file
            string json = File.ReadAllText(@"C:\Users\win 10\Desktop\Ayesha.txt");
            JsonSerializer serializer = new JsonSerializer();
            var playerList = JsonConvert.DeserializeObject<List<Table>>(json);
            return playerList;

        }

        public List<String> GetJobs(String Filename)
        {


            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\win 10\Desktop\Jobs.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<String> Jobs = (List<String>)serializer.Deserialize(file, typeof(List<String>));
                return Jobs;
            }


        }

        public int SaveStringData(List<String> Actual)
        {
            if (Actual == null) { return 0; }
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            String path = String.Concat(@"C:\Users\My Book\Desktop\Jobs.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Actual);
            }
            return 1;
        }
        public  IEnumerable<List<T>> splitList<T>(List<T> locations, int nSize)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
        public Char CharacterGenerator(Char c)
        {
            Random r = new Random();
            Char result = ' ';
            if (c == '*')
            {
                Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '!', '?', '-', '_', '@', '$', '#', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'A')
            {
                Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'c')
            {
                Char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'C')
            {
                Char[] arr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'd')
            {
                Char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'D')
            {
                Char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'X')
            {
                Char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else if (c == 'b')
            {
                Char[] arr = { '0', '1' };
                int randomvalue = r.Next(arr.Length);
                result = arr[randomvalue];
            }
            else
            {
                result = c;
            }
            return result;
        }
        public String PatternGenerator(String p)
        {
            Random r = new Random();
            String final = "";
            String temp = "";
            String result = " ";
            List<String> L = new List<string>();
            List<String> L2 = new List<string>();
            String temp3 = "";
            int temp2 = 0;
            int iterator = 0;
            while (iterator < p.Length)
            {
                if (p[iterator] == '[')
                {

                    iterator = iterator + 1;
                    //Console.WriteLine(p[iterator]);
                    while (p[iterator] != ']')
                    {
                        while (p[iterator] != '|')
                        {
                            if (p[iterator] == '|' || p[iterator] == ']')
                            {
                                break;
                            }
                            temp = temp + p[iterator];

                            iterator = iterator + 1;
                        }

                        temp3 = temp.ToString();
                        L.Add(temp3);
                        if (p[iterator] == ']')
                        {
                            iterator = iterator + 1;
                            temp = "";
                            temp3 = "";
                            break;
                        }
                        iterator = iterator + 1;
                        temp = "";
                        temp3 = "";

                    }

                    int randomvalue = r.Next(L.Count);
                    result = L[randomvalue];
                    final = final + result;
                    L2.Add(result);
                    L.Clear();
                }
                //'*', 'A', 'c', 'C', 'd', 'D', 'X', 'b'
                else if (p[iterator] == '*')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('*')).ToString();
                            L2.Add((CharacterGenerator('*')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('*')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'A')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('A')).ToString();
                            final = final + c;
                            L2.Add((CharacterGenerator('A')).ToString());
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('A')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'c')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('c')).ToString();
                            L2.Add((CharacterGenerator('c')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('c')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'C')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('C')).ToString();
                            final = final + c;
                            L2.Add((CharacterGenerator('C')).ToString());
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('C')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'd')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('d')).ToString();
                            L2.Add((CharacterGenerator('d')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('d')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'D')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('D')).ToString();
                            L2.Add((CharacterGenerator('D')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('D')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'X')
                {

                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('X')).ToString();
                            L2.Add((CharacterGenerator('X')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('X')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }
                }
                else if (p[iterator] == 'b')
                {
                    String c = "";

                    if (p[iterator + 1] == '{')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';

                        for (int i = 0; i < temp2; i++)
                        {
                            c = (CharacterGenerator('b')).ToString();
                            L2.Add((CharacterGenerator('b')).ToString());
                            final = final + c;
                        }
                        iterator = iterator + 3;

                    }
                    else if (p[iterator + 1] == '(')
                    {
                        char foo = p[iterator + 2];
                        temp2 = foo - '0';
                        int rInt = r.Next(0, temp2);
                        String TempChar = (CharacterGenerator('b')).ToString();
                        for (int i = 0; i < temp2; i++)
                        {

                            L2.Add(TempChar);
                        }
                        iterator = iterator + 3;
                        final = final + TempChar;
                    }

                }
                else {
                    if (p[iterator] == '}')
                    {
                        final = final + "";
                        iterator = iterator + 1;



                    }
                    else if (p[iterator] == ')')
                    {
                        final = final + "";
                        iterator = iterator + 1;

                    }
                    else
                    {
                        final = final + p[iterator];
                        iterator = iterator + 1;
                    }
                }
            }


            return final;

        }
        public bool CheckGender(List<Table> myTable, String tableName)
        {
            foreach(var Table in myTable)
            {
                if(Table.TableName==tableName)
                {
                    foreach(var Column in Table.ColumnsList)
                    {
                        if(Column.Name=="Gender")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckCode(List<Table> myTable, String tableName)
        {
            foreach (var Table in myTable)
            {
                if (Table.TableName == tableName)
                {
                    foreach (var Column in Table.ColumnsList)
                    {
                        if (Column.Name == "Code")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckHireDate(List<Table> myTable, String tableName)
        {
            foreach (var Table in myTable)
            {
                if (Table.TableName == tableName)
                {
                    foreach (var Column in Table.ColumnsList)
                    {
                        if (Column.Name == "HireDate")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public Boolean sensitivityTest(String source, String target)
        {
            List<String> TableRules = new List<string>();
            List<String> ColumnRules = new List<string>();

            List<FuzzyStringComparisonOptions> options = new List<FuzzyStringComparisonOptions>();

            // Choose which algorithms should weigh in for the comparison
            options.Add(FuzzyStringComparisonOptions.UseOverlapCoefficient);
            options.Add(FuzzyStringComparisonOptions.UseLongestCommonSubsequence);
            options.Add(FuzzyStringComparisonOptions.UseLongestCommonSubstring);

            // Choose the relative strength of the comparison - is it almost exactly equal? or is it just close?
            FuzzyStringComparisonTolerance tolerance = FuzzyStringComparisonTolerance.Strong;

            // Get a boolean determination of approximate equality
            bool result = source.ApproximatelyEquals(target, tolerance, options.ToArray());
            Console.WriteLine(result);
            return result;
        }
       
        public bool fetchRules(List<String> TableRules, List<String> ColumnRules)
        {
            String fileName = @"C:\Users\My Book\Desktop\Rules.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            bool check = false;
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                TableRules.Add(words[0]);
                ColumnRules.Add(words[1]);
                // Use a tab to indent each line of the file.
                check = true;

            }
            return true;
        }
    }

  
}

    

