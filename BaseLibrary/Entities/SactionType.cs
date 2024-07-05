using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class SactionType : BaseEntity
    {
        //Many to one relationship with Vacation
        public List<Saction>? Sactions { get; set; }
    }
}
