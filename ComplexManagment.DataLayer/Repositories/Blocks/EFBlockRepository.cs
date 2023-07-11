using ComplexManagment.DataLayer.Dto.Blocks;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Blocks;

public class EFBlockRepository : BlockRepository
{
    private readonly EFDataContext _context;
    private readonly UnitOfWork _unitOfWork;

    public EFBlockRepository(EFDataContext context,UnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    
    public bool IsDuplicateNameByComplexId(string name,int complexId)
    {
        return _context.Blooks.Any(_ => 
            _.ComplexId == complexId &&
            _.Name == name);
    }

    public int GetTotalUnitCountByComplexId(int complexId)
    {
        return _context.Blooks
            .Where(_ => _.ComplexId == complexId)
            .Select(_ => _.UnitCount)
            .Sum();
    }

    public int GetTotalUnitCountByComplexIdWithOutThisBlockId(
        int id,
        int complexId)
    {
        return _context.Blooks.Where(_ =>
                _.ComplexId == complexId &&
                _.Id != id)
            .Select(_ => _.UnitCount)
            .Sum();
    }

    public void Add(Blook blook)
    {
        _context.Blooks.Add(blook);
        _unitOfWork.Complete();
    }

    public Blook? FindById(int id)
    {
        return _context.Blooks
            .FirstOrDefault(_ => _.Id == id);
    }

    public bool IsDuplicateNameByComplexId(
        int id,
        string name,
        int complexId)
    {
        return _context.Blooks
            .Any(_ => _.Name == name &&
                      _.ComplexId == complexId &&
                      _.Id != id);
    }

    public void Update(Blook blook)
    {
        _context.Blooks.Update(blook);
        _unitOfWork?.Complete();
    }
    public int blockUnitCount(int blockId)
    {
        return _context.Blooks
            .Where(_ => _.Id == blockId)
            .Select(_ => _.UnitCount)
            .FirstOrDefault();
    }

    public List<GetAllBlooksDto> GetAllBlooks()
    {
        var resualt = _context.Blooks
            .Select(_ => new GetAllBlooksDto
            {
                Id=_.Id,
                Name = _.Name,
                UnitCount = _.UnitCount,
                BlooksCount = _.Units.Count(),
                RemainBlook = _.UnitCount - _.Units.Count()
            }).ToList();
        return resualt;
    }
    public bool IsExistsByBlockId(int blockId)
    {
        return _context.Blooks.Any(_ => _.Id == blockId);
    }

    public GetOneBlookDto GetOneBlookById(int blockId)
    {
        return
            _context.Blooks.Where(_ => _.Id == blockId)
            .Select(_=> new GetOneBlookDto
            {
                Id= _.Id,
                Name= _.Name,
                GetUnitDtos=_.Units.Select(unit=> new GetUnitDto
                {
                    Name=unit.Name,
                    ResidenceName=unit.Resident,
                }).ToList()
            }).FirstOrDefault();
    }
}