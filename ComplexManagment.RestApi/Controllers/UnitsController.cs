using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Blocks;
using ComplexManagment.DataLayer.Repositories.Units;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers;

[Route("units")]
[ApiController]
public class UnitsController : Controller
{
    private readonly UnitRepository _unitRepository;
    private readonly BlockRepository _blockRepository;

    public UnitsController(UnitRepository unitRepository,BlockRepository blockRepository)
    {
        _unitRepository = unitRepository;
        _blockRepository = blockRepository;
    }

    [HttpPost]
    public void Add(AddUnitDto dto)
    {
        var isExistBlockId =_blockRepository.IsExistsByBlockId(dto.BlookId);
        if (!isExistBlockId)
        {
            throw new Exception("block not found");
        }

        var duplicateUnitName = _unitRepository.DuplicateUnitName(dto.Name,dto.BlookId);
        if (duplicateUnitName)
        {
            throw new Exception("unit name duplicate");
        }

        var blockUnitCount = _blockRepository.blockUnitCount(dto.BlookId);
        var totalUnitInBlock = _unitRepository.totalUnitInBlock(dto.BlookId);

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

        _unitRepository.Add(unit);
    }
    [HttpGet]
    public List<GetAllUnitsDto> GetAllUnits()
    {
        return _unitRepository.GetAllUnits();
    }
    

    
}