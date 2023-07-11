using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Complexs
{
    public class GetAllComplexWithBlookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetAllBlooks> GetAllBlooks  { get; set; }
    }

    public class GetAllBlooks
    {
        public string Name { get; set; }
        public int UnitCount { get; set; }
    }
}
