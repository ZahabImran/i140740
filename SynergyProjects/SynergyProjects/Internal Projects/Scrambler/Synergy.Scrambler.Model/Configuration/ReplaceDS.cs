using System;

namespace Synergy.Scrambler.Model.Configuration
{
    public class ReplaceDS : IMappingConfig
    {
        //TODO: Add relevant properties of ReplaceDS
        public string Name { get; set; }
        public int Rows { get; set; }
        public String MaskChar { get; set; }
        public String HashCriteria { get; set; }
        
        public String ReplaceWith { get; set; }
        public int ML { get; set; }


        public String Criteria;
        public int NumberOfRows;


        public void StoreInObject(String C, String RW)
        {
            Name = C;
            Criteria = C;
            ReplaceWith = RW;
            
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

        public void StoreInObject(string C, int NOR)
        {
            throw new NotImplementedException();
        }
    }
}