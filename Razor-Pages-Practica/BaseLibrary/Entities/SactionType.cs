

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class SactionType : BaseEntity
    {
        [JsonIgnore]
        public List<Sanction>? Sanctions { get; set; }
    }
}
