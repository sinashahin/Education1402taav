using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Complexs
{
    public class GetOneComplexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int BlockCount { get; set; }
        public int SubmitedUnitCount { get; set; }
        public int RemainUnitCount { get; set; }
    }
}
