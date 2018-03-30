using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergy.Scrambler.Model.Configuration
{
    public class Hashing:IMappingConfig
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int ML { get; set; }

        public String HashCriteria { get; set;  }
        public String MaskChar { get; set; }

       public String ReplaceWith { get; set; }

        public String Criteria;
        public int NumberOfRows;
        public int MaskingLength;


        public void StoreInObject(String C, int NOR, int ML, String MaskChar)
        {
            Name = C;
            Criteria = C;
            NumberOfRows = NOR;
            Rows = NOR;
            MaskingLength = ML;
            this.ML = MaskingLength;
            this.MaskChar = MaskChar;
        }

        public void StoreInObject(string C, int NOR , String HC)
        {
            Name = C;
            Criteria = C;
            NumberOfRows = NOR;
            Rows = NOR;
            HashCriteria = HC;
            
        }

        public void StoreInObject(string C, int NOR, int ML)
        {
            throw new NotImplementedException();
        }

        public void StoreInObject(string C, int NOR)
        {
            throw new NotImplementedException();
        }

        public void StoreInObject(string C, string RW)
        {
            throw new NotImplementedException();
        }
    }
}
