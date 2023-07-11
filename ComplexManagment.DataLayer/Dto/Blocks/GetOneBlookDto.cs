using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Blocks
{
    public class GetOneBlookDto
    {
        public GetOneBlookDto()
        {
            GetUnitDtos = new List<GetUnitDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetUnitDto> GetUnitDtos { get; set; }
    }

    public class GetUnitDto
    {
        public string Name { get; set; }
        public UnitType ResidenceName { get; set; }
    }
}
