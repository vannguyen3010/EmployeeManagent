using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity  
    {
        //Relationship : One to Many with Employee

        public List<Employee>? Employees { get; set; }
        //Many to the relationship with city
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
