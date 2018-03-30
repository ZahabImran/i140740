using System;
using System.Xml.Serialization;
using System.IO;

namespace Synergy.Scrambler.Engine
{
   public class Replacement:Config
    {
        public String TableName;
        public String ColumnName;
        public String Criteria;
        public int NumberOfRows;

        public Replacement()
        {

        }
      public  Replacement(String TN, String CN, String C, int NOR)
        {
            TableName = TN;
            ColumnName = CN;
            Criteria = C;
            NumberOfRows = NOR;
        }
        public int SaveConfig()
        {
            var replace = new Replacement(TableName,ColumnName,Criteria,NumberOfRows);

            // TODO init your garage..

            XmlSerializer xs = new XmlSerializer(typeof(Replacement));
            TextWriter tw = new StreamWriter(@"C:\Users\zahab.imran\Desktop\Replacement.xml");
            xs.Serialize(tw, replace);
            return 1;
        }
    }
}
