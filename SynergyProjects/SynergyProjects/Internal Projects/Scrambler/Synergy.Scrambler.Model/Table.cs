using System.Collections.Generic;

namespace Synergy.Scrambler.Model
{
   public class Table
    {
        public string TableName { get; set; }

        public List<Columns> ColumnsList = new List<Columns>();
    }
}
