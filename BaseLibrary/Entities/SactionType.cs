using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class SactionType : BaseEntity
    {
        //Many to one relationship with Vacation
        [JsonIgnore]
        public List<Saction>? Sactions { get; set; }
    }
}
