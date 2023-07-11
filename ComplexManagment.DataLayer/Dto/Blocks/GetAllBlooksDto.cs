using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Blocks
{
    public class GetAllBlooksDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        
        public int UnitCount { get; set; }
        
        public int BlooksCount { get;  set; }
        
        public int RemainBlook { get; set; }

    }
}
