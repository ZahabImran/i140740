using System.Collections.Generic;

namespace Synergy.Scrambler.Model.Configuration
{
    public class TableCofig
    {
        public string TableName { get; set; }

        public List<ColumnConfig> ColumnConfigs = new List<ColumnConfig>();
    }
}