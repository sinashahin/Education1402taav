using ComplexManagment.DataLayer.Dto.UsageType;
using ComplexManagment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.UsageTypes
{
    public class EFUsageTypeRepository : UsageTypeRepository
    {
        
        private readonly DbSet<UsageType> _usageTypes;
        private readonly EFDataContext _context;
        private readonly UnitOfWork _unitOfWork;
        public EFUsageTypeRepository(EFDataContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _usageTypes = _context.Set<UsageType>();
            _unitOfWork = unitOfWork;
        }

        public void Add(UsageType usageType)
        {
            _usageTypes.Add(usageType);
            _unitOfWork.Complete();
        }

        public List<GetAllUsageTypeDto> GetAllUsageType()
        {
            
            var usageType =_usageTypes.Select(_=> new GetAllUsageTypeDto
            {
                Id=_.Id,
                Name=_.Name,
            }).ToList();
            return usageType;
        }
    }
}
