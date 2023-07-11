using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Units;

public class EFUnitRepository : UnitRepository
{
    private readonly EFDataContext _context;

    public EFUnitRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Unit unit)
    {
        _context.Units.Add(unit);
        _context.SaveChanges();
    }

    public bool DuplicateUnitName(string name,int blockId)
    {
       return _context.Units.Any(
            _ => _.Name == name &&
                 _.BlookId == blockId);
    }

    public List<GetAllUnitsDto> GetAllUnits()
    {
        var result=_context.Units
            .Select(_=>new GetAllUnitsDto
            {
               Id= _.Id,
                Name = _.Name,
                BlookId= _.BlookId,
                BlookName=_.Blook.Name,
                ComplexId=_.Blook.ComplexId,
                ComplexName=_.Blook.Complex.Name,

            }).ToList();
        return result;
    }



    public int totalUnitInBlock(int blockId)
    {
        return _context.Units
            .Count(_ => _.BlookId == blockId);
    }
}