using Newtonsoft.Json;

namespace Synergy.Scrambler.Model.Configuration
{
    public class ColumnConfig: Columns
    {
        [JsonConverter(typeof(MappingConfigConverter))]
        public IMappingConfig MappingConfig { get; set; }
    }
}