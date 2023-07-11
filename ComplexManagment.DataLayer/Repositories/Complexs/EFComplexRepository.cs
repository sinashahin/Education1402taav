using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

public class EFComplexRepository : ComplexRepository
{
    private readonly EFDataContext _context;
    private readonly UnitOfWork _unitOfWork;

    public EFComplexRepository(EFDataContext context,UnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public void Add(Complex complex)
    {
        _context.Complexs.Add(complex);
        _unitOfWork.Complete();
    }

    public List<GetAllComplexDto> GetAll(string? searchName)
    {
        var result = _context.Complexs
            .Select(_ => new GetAllComplexDto
            {
                Id = _.Id,
                Name = _.Name,
                UnitCount = _.UnitCount,
                SubmitedUnitCount=_.Blooks.SelectMany(_=>_.Units).Count(),
                RemainUnitCount=_.UnitCount - _.Blooks.SelectMany(_ => _.Units).Count()

            });

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            result = result.Where(_ => _.Name.Contains(searchName));
        }

        return result.ToList();
    }

    public bool IsExistsById(int id)
    {
        return _context.Complexs.Any(_ => _.Id == id);
    }

    public int GetUnitCountById(int id)
    {
        return _context.Complexs
            .Where(_ => _.Id == id)
            .Select(_ => _.UnitCount)
            .FirstOrDefault();
    }

    List<GetAllUsageTypeByComplexId> ComplexRepository.GetAllUsageTypeByComplexId(int id)
    {
        return 
            (from usage in _context.Set<UsageType>()
             join cu in _context.Set<ComplexUsageType>() on usage.Id equals cu.UsageTypeId
             where cu.ComplexId==id
             select new GetAllUsageTypeByComplexId
             {
                 UsageTypeId = usage.Id,
                 UsageTypeName=usage.Name
             }).ToList();

    }

    public GetOneComplexDto GetOneComplexDto(int complexId)
    {
        return
            _context.Complexs.Where(_ => _.Id == complexId)
            .Select(_ => new GetOneComplexDto
            {
                Id = _.Id,
                Name = _.Name,
                UnitCount = _.UnitCount,
                BlockCount = _.Blooks.Count(),
                SubmitedUnitCount = _.Blooks.SelectMany(_ => _.Units).Count(),
                RemainUnitCount = _.UnitCount - _.Blooks.SelectMany(_ => _.Units).Count()
            }).FirstOrDefault();
    }

    public List<GetAllComplexWithBlookDto> GetAllComplexWithBlooks()
    {
        return 
            _context.Complexs.Select(_=> new GetAllComplexWithBlookDto
            {
                Id= _.Id,
                Name= _.Name,
                GetAllBlooks=_.Blooks.Select(blook=> new GetAllBlooks
                {
                    Name= blook.Name,
                    UnitCount= blook.UnitCount,
                }).ToList(),
            }).ToList();
    }
}