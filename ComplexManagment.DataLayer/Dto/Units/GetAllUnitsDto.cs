using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Units
{
    public class GetAllUnitsDto
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public int BlookId { get; set; }
        
        public string BlookName { get; set; }
        
        public int ComplexId { get; set; }
        
        public string ComplexName { get; set; }

    }
}
