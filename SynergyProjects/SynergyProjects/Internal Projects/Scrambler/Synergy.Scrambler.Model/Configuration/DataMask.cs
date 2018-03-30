using System;

namespace Synergy.Scrambler.Model.Configuration
{
   public class DataMask:IMappingConfig
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int ML { get; set; }

        public String MaskChar { get; set; }

        public String HashCriteria { get; set; }

        public string ReplaceWith
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public String Criteria;
        public int NumberOfRows;
        public int MaskingLength;


        public void StoreInObject(String C, int NOR, int ML,String MaskChar)
        {
            Name = C;
            Criteria = C;
            NumberOfRows = NOR;
            Rows = NOR;
            MaskingLength = ML;
            this.ML = MaskingLength;
            this.MaskChar = MaskChar;
        }

        public void StoreInObject(string C, int NOR)
        {
            throw new NotImplementedException();
        }

        public void StoreInObject(string C, int NOR, int ML)
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
