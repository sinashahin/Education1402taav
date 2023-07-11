using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.UsageType;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.UsageTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComplexManagment.Controllers
{
    [Route("usage-types")]
    [ApiController]
    public class UsageTypesController : Controller
    {
        private readonly UsageTypeRepository _usagetypeRepository;
        public UsageTypesController(UsageTypeRepository usageTypeRepository)
        {
            _usagetypeRepository = usageTypeRepository;
        }
        [HttpPost]
        public void Add(AddUsageTYpeDto dto) 
        {
           var usageType=new UsageType()
           {
               Name=dto.Name,
           };
            _usagetypeRepository.Add(usageType);
        }
        [HttpGet]
        public List<GetAllUsageTypeDto> GetAll() 
        {
            return _usagetypeRepository.GetAllUsageType();
        }
    }
}
