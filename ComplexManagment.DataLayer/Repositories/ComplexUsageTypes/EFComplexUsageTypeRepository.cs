using ComplexManagment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.ComplexUsageTypes
{
    public class EFComplexUsageTypeRepository : ComplexUsageTypeRepository
    {
        private readonly EFDataContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly DbSet<ComplexUsageType> _complexUsageTypes;
        public EFComplexUsageTypeRepository(EFDataContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _complexUsageTypes = _context.Set<ComplexUsageType>();
            _unitOfWork = unitOfWork;

        }

        public void Add(ComplexUsageType complexUsageType)
        {
            _complexUsageTypes.Add(complexUsageType);
            _unitOfWork.Complete();
        }
    }
}
