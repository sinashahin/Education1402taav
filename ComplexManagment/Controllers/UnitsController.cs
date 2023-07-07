using ComplexManagment.Dto.Units;
using ComplexManagment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers;

[Route("units")]
[ApiController]
public class UnitsController : Controller
{
    private readonly EFDataContext _context;

    public UnitsController(EFDataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public void Add(AddUnitDto dto)
    {
        var isExistBlockId = _context.Blooks.Any(_ => _.Id == dto.BlookId);
        if (!isExistBlockId)
        {
            throw new Exception("block not found");
        }

        var duplicateUnitName = _context.Units.Any(
            _ => _.Name == dto.Name &&
                 _.BlookId == dto.BlookId);
        if (duplicateUnitName)
        {
            throw new Exception("unit name duplicate");
        }

        var blockUnitCount = _context.Blooks
            .Where(_ => _.Id == dto.BlookId)
            .Select(_ => _.UnitCount)
            .First();
        var totalUnitInBlock = _context.Units
            .Count(_ => _.BlookId == dto.BlookId);

        if (totalUnitInBlock == blockUnitCount)
        {
            throw new Exception("unit count exception");
        }
        
        var unit = new Unit()
        {
            Name = dto.Name,
            BlookId = dto.BlookId,
            Resident = dto.Resident
        };

        _context.Units.Add(unit);
        _context.SaveChanges();
    }
}