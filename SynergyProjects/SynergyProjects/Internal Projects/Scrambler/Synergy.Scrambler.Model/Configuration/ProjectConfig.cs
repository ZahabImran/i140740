
using System.Collections.Generic;

namespace Synergy.Scrambler.Model.Configuration
{
    public  class ProjectConfig
    {
        public ProjectType ProjectType { get; set; }
        public string ConnectionString { get; set; }
        public List<TableCofig> TableConfigs = new List<TableCofig>();
    }
}
