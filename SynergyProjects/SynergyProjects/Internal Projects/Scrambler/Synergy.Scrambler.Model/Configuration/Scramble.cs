using System;

namespace Synergy.Scrambler.Model.Configuration
{
    public class Scramble: IMappingConfig
    {
        public string Name { get; set; }
        public int Rows { get; set; }

        public int ML { get; set; }

        public String MaskChar { get; set; }

        public String HashCriteria { get; set;  }

      public String ReplaceWith { get; set; }

        public String Criteria;
        public int NumofRows;
        public String DataType;
      
        public void StoreInObject(String C, int NOR)
        {
            
            Name = C;
            Criteria = C;
            NumofRows = NOR;
            Rows = NumofRows;
        }

        public void StoreInObject(string C, int NOR, int ML)
        {
            throw new NotImplementedException();
        }

        public void StoreInObject(string C, int NOR, int ML, string MaskChar)
        {
            throw new NotImplementedException();
        }

        public void StoreInObject(string C, int NOR, string HC)
        {
            throw new NotImplementedException();
        }

        public void StoreInObject(string C, string RW)
        {
            throw new NotImplementedException();
        }
    }
}
