using System;
using System.Collections.Generic;
using Synergy.Scrambler.Engine;
using Synergy.Scrambler.Common;

using Synergy.Scrambler.Model.Configuration;
namespace Synergy.Scrambler.MaskingSets
{
    public class DataMaskingList
    {
     
            IScramblerEngine ISE;
            List<String> Data = new List<string>();
            List<String> SData = new List<string>();
            CommonFunctions Func = new CommonFunctions();
            public List<String> MakeMaskedData(ProjectConfig PC)
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

            public List<String> ActualMasking(List<String> Data,ProjectConfig PC)
            {
                List<String> Scrambled = new List<string>();
            int j = 0;


            foreach (var configTable in PC.TableConfigs)
            {


                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    int i = 0;

                    while (i < configColumn.MappingConfig.Rows)
                    {
                        Scrambled.Add(Masking(Data[j].ToString(),configColumn.MappingConfig.ML));
                        i++;
                        j++;
                    }

                }
            }

            return Scrambled;

            }
        public String Masking(String Actual,int length)
        {
            String Masked="";

            String input = Actual;

            if (input.Length > length)
            {
                string FirstPart = input.Substring(0, length);
                Console.WriteLine(FirstPart);
          

                //take last 4 characters
                int len = input.Length;
                int len1 = FirstPart.Length;
                int len2 = len - len1;
                string lastPart = input.Substring(len1, len2);
             
                //take the middle part (XXXXXXXXX)

                string middlePart = new String('X', length);

                String returnVal= middlePart + lastPart;
                return returnVal;
                
            }
            else
            {
                string middlePart = new String('X', input.Length);

                return middlePart;
              
            }

        }




        }


}
