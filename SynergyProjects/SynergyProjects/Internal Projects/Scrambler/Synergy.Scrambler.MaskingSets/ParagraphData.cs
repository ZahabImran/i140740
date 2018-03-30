using Synergy.Scrambler.Common;
using Synergy.Scrambler.Engine;
using Synergy.Scrambler.Model.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergy.Scrambler.MaskingSets
{
    public  class ParagraphData
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
    }
}
