using ComplexManagment.Dto.Blocks;
using ComplexManagment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers;

[Route("blocks")]
[ApiController]
public class BlocksController : Controller
{
    private readonly EFDataContext _context;

    public BlocksController(EFDataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public void Add(AddBlockDto dto)
    {
        var isExistsComplex =
            _context.Complexs.Any(_ => _.Id == dto.ComplexId);
        if (!isExistsComplex)
        {
            throw new Exception("complex not found");
        }
        var isDuplicateBlockName =
            _context.Blooks.Any(_ => _.Name == dto.Name && _.ComplexId == dto.ComplexId);
        if (isDuplicateBlockName)
        {
            throw new Exception("name duplicate");
        }

        CheckComplexUnitCount(dto.UnitCount, dto.ComplexId);
        
        var block = new Blook()
        {
            ComplexId = dto.ComplexId,
            Name = dto.Name,
            UnitCount = dto.UnitCount
        };

        _context.Blooks.Add(block);
        _context.SaveChanges();
    }

    [HttpPatch("{id}")]
    public void Update([FromRoute]int id,[FromBody]UpdateBlockDto dto)
    {
        var block = _context.Blooks.FirstOrDefault(_ => _.Id == id);

        if (block == null)
        {
            throw new Exception("block not found");
        }
        
        var isDuplicateBlockName =
            _context.Blooks.Any(_ => _.Name == dto.Name &&
                                     _.ComplexId == block.ComplexId &&
                                     _.Id != block.Id);
        if (isDuplicateBlockName)
        {
            throw new Exception("name duplicate");
        }

        var isExistUnit = _context.Units.Any(_ => _.BlookId == block.Id);

        if (!isExistUnit)
        {
            var totalBlockUnitCount = _context.Blooks
                .Where(_ => _.ComplexId == block.ComplexId &&
                            _.Id != block.Id)
                .Select(_ => _.UnitCount).Sum();
            var complexUnitCount = _context.Complexs
                .Where(_ => _.Id == block.ComplexId)
                .Select(_ => _.UnitCount)
                .First();
            if (totalBlockUnitCount + dto.UnitCount > complexUnitCount)
            {
                throw new Exception("totalBlockUnitCount");
            }
            block.UnitCount = dto.UnitCount;
        }
        
        block.Name = dto.Name;

        _context.SaveChanges();
    }

    private void CheckComplexUnitCount(int dtoUnitCount,int complexId)
    {
        var totalBlockUnitCount = _context.Blooks
            .Where(_ => _.ComplexId == complexId)
            .Select(_ => _.UnitCount).Sum();
        var complexUnitCount = _context.Complexs
            .Where(_ => _.Id == complexId)
            .Select(_ => _.UnitCount)
            .First();
        if (totalBlockUnitCount + dtoUnitCount > complexUnitCount)
        {
            throw new Exception("totalBlockUnitCount");
        }
    }
}