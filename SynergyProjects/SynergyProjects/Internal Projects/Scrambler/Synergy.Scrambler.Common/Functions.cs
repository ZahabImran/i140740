using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Synergy.Scrambler.Model;
using Synergy.Scrambler.Model.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
namespace Synergy.Scrambler.Common
{
    public class Functions
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
        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
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
        public int GetLength(ProjectConfig PC)
        {
            int i = 0;
            foreach (var configTable in PC.TableConfigs)
            {


                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    i++;
                }
            }



            return i;


        }
        public int SaveStringData(List<String> Actual, List<String> Tampered)
        {
            if (Actual == null) { return 0; }
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            String path = String.Concat(@"C:\Users\zahab.imran\Desktop\Actual.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Actual);
            }


            if (Tampered == null) { return 0; }
            serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            path = String.Concat(@"C:\Users\zahab.imran\Desktop\Tampered.txt");
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
            String path = String.Concat(@"C:\Users\zahab.imran\Desktop\ActualMask.txt");
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Actual);
            }


            if (Tampered == null) { return 0; }
            serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            path = String.Concat(@"C:\Users\zahab.imran\Desktop\TamperedMask.txt");
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

        public List<String> GetJobs(String Filename)
        {


            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\zahab.imran\Desktop\Jobs.txt"))
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
            String path = String.Concat(@"C:\Users\zahab.imran\Desktop\Jobs.txt");
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
    }
}

    

