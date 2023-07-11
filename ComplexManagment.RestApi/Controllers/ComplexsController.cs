using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Complexs;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers
{
    [Route("complexs")]
    [ApiController]
    public class ComplexsController : ControllerBase
    {

        private readonly ComplexRepository _complexRepository;
        public ComplexsController(ComplexRepository complexRepository)
        {
            _complexRepository = complexRepository;
        }
        
        [HttpPost]
        public void Add([FromBody]AddComplexDto dto)
        {
            var complex = new Complex()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };
            
            _complexRepository.Add(complex);
        }
        
        [HttpGet]
        public List<GetAllComplexDto> GetAll([FromQuery]string? name)
        {
            return _complexRepository.GetAll(name);
        }
        [Route("{id}/usage-type")]
        [HttpGet]
        public List<GetAllUsageTypeByComplexId> GetAllUsageTypes([FromRoute] int id)
        {
            return _complexRepository.GetAllUsageTypeByComplexId(id);
        }
        [Route("{id}")]
        [HttpGet]
        public GetOneComplexDto GetOneComplexDto([FromRoute]int id)
        {
            return _complexRepository.GetOneComplexDto(id);
        }
        [Route("block")]
        [HttpGet]
        public List<GetAllComplexWithBlookDto> GetAllComplexWithBlooks()
        {
            return _complexRepository.GetAllComplexWithBlooks();
        }

        //[Route("{}")]
        //[HttpGet]


        // private readonly EFDataContext _context;
        //
        // public ComplexsController(EFDataContext context)
        // {
        //     _context = context;
        // }
        //
        // [HttpPost]
        // public void Add([FromBody] AddComplexDto dto)
        // {
        //     var complex = new Complex
        //     {
        //         Name = dto.Name,
        //         UnitCount = dto.UnitCount,
        //     };
        //
        //     _context.Complexs.Add(complex);
        //     _context.SaveChanges();
        // }
        //
        // [HttpGet("{id}/blocks")]
        // public GetComplexByIdWithBlocksDto GetComplexByIdWithBlocks(
        //     [FromRoute] int id)
        // {
        //     var query =
        //         (from complex in _context.Complexs
        //             join block in _context.Blooks on complex.Id equals block.ComplexId
        //                 into blocks
        //             from block in blocks.DefaultIfEmpty()
        //             join unit in _context.Units on block.Id equals unit.BlookId
        //                 into units
        //             from unit in units.DefaultIfEmpty()
        //             where complex.Id == id
        //             select new
        //             {
        //                 ComplexId = complex.Id,
        //                 ComplexName = complex.Name,
        //                 BlockId = block != null ? block.Id : (int?)null,
        //                 BlockUnitCount = block != null ? block.UnitCount : (int?)null,
        //                 BlockName = block != null ? block.Name : null,
        //                 UnitId = unit != null ? unit.Id : (int?)null
        //             }).ToList();
        //
        //     var result =
        //         (from item in query
        //             group item by new
        //             {
        //                 ComplexId = item.ComplexId,
        //                 ComplexName = item.ComplexName
        //             }
        //             into complexGroups
        //             select new GetComplexByIdWithBlocksDto()
        //             {
        //                 Id = complexGroups.Key.ComplexId,
        //                 Name = complexGroups.Key.ComplexName,
        //                 Blocks = (from itemComplexGroup in complexGroups
        //                         group itemComplexGroup by new
        //                         {
        //                             BlockId = itemComplexGroup.BlockId,
        //                             BlockName = itemComplexGroup.BlockName,
        //                             BlockUnitCount = itemComplexGroup.BlockUnitCount
        //                         }into blockGroups
        //                             select new GetBlockDto()
        //                             {
        //                                 BlockId = blockGroups.Key.BlockId,
        //                                 BlockName = blockGroups.Key.BlockName,
        //                                 BlockUnitCount = blockGroups.Key.BlockUnitCount,
        //                                 UnitRegisteredCount = blockGroups
        //                                     .Where(_=>_.UnitId != null)
        //                                     .Select(_=>_.UnitId)
        //                                     .Count()
        //                             }).ToList()
        //             }).FirstOrDefault();
        //
        //     return result;
        // }
    }
}