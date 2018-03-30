using Synergy.Scrambler.Engine;
using Synergy.Scrambler.Common;

using Synergy.Scrambler.Model.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Synergy.Scrambler.MaskingSets
{
    public class ScrambledData
    {
        IScramblerEngine ISE;
        List<String> Data = new List<string>();
        List<String> SData = new List<string>();
        CommonFunctions Func = new CommonFunctions();
        public List<String> MakeScrambledData(ProjectConfig PC)
        {
            if (PC.ConnectionString == "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Data; Integrated Security = True ;")
            {
                ISE = new MsSqlBusinessLogic("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = CopyDb; Integrated Security = True ;");
                foreach (var configTable in PC.TableConfigs)
                {
                    foreach (var configColumn in configTable.ColumnConfigs)
                    {

                        Data = ISE.FetchData(configTable.TableName, configColumn.Name, configColumn.MappingConfig.Rows);


                    }

                }

               
               

                return Data;
            }
            return Data;

        }
      
        public List<String> ActualScrambling(List<String> Data)
        {
            List<String> Scrambled = new List<string>();
            foreach (var data in Data)
            {
                String str=data.ToString(); ;
                String rand=str;
                while (str == rand)
                {


                    // The random number sequence
                    Random num = new Random();

                    // Create new string from the reordered char array
                    rand = new string(str.ToCharArray().
                                   OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
                }
                Scrambled.Add(rand);

            }

            return Scrambled;

        }
            [Microsoft.SqlServer.Server.SqlFunction()]

        public String ActualScrambling(String Data)
        {
            String Scrambled ="" ;
            foreach (var data in Data)
            {
                String str = data.ToString(); ;
                String rand = str;
                while (str == rand)
                {


                    // The random number sequence
                    Random num = new Random();

                    // Create new string from the reordered char array
                    rand = new string(str.ToCharArray().
                                   OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
                }
                Scrambled= rand ;

            }

            return Scrambled;

        }

    }
}
