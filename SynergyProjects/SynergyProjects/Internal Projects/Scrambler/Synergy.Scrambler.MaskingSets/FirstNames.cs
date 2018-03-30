using System;
using System.Collections.Generic;

namespace Synergy.Scrambler.MaskingSets
{
    public class FirstNames
    {
        public List<String> _FirstNames = new List<string>();
        public List<String> RandomNames(int count)
        {
            var lines = System.IO.File.ReadAllLines("C:/Users/zahab.imran/Desktop/FirstName.txt");
            var r = new Random();
            for (int i = 0; i < count; i++)
            {
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                _FirstNames.Add(line.ToString());

            }
            return _FirstNames;
        }

    }
}
