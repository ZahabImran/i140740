
using System;

namespace Synergy.Scrambler.Model.Configuration
{

    public interface IMappingConfig
    {
        string Name { get; set; }
         int Rows { get; set; }
        int ML { get; set; }
        
        String ReplaceWith { get; set; }
        String HashCriteria { get; set; }
        String MaskChar { get; set; }

        void StoreInObject ( String C , String RW );
        void StoreInObject( String C, int NOR);
        void StoreInObject(String C, int NOR,int ML);
        void StoreInObject(String C, int NOR, String HC);

        void StoreInObject(String C, int NOR, int ML,String MaskChar);

    }
}