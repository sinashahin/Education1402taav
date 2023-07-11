using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Dto.ComplexUsageType;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.ComplexUsageTypes;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers
{
    [Route("complex-Usage-type")]
    public class ComplexUsageTypesController : Controller
    {
        private readonly ComplexUsageTypeRepository _complexUsageTypeRepository;
        public ComplexUsageTypesController(ComplexUsageTypeRepository complexUsageTypeRepository)
        {
            _complexUsageTypeRepository = complexUsageTypeRepository;
        }
        [HttpPost]
        public void Add(AddComplexUsageTypeDto dto)
        {
            var complexUsageType = new ComplexUsageType()
            {
                ComplexId = dto.ComplexId,
                UsageTypeId = dto.UsageTypeId,
            };
            _complexUsageTypeRepository.Add(complexUsageType);
        }
        

    }


}
