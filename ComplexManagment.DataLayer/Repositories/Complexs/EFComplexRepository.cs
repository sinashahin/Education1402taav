using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

public class EFComplexRepository : ComplexRepository
{
    private readonly EFDataContext _context;

    public EFComplexRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Complex complex)
    {
        _context.Complexs.Add(complex);
        _context.SaveChanges();
    }

    public List<GetAllComplexDto> GetAll(string? searchName)
    {
        var result = _context.Complexs
            .Select(_ => new GetAllComplexDto
            {
                Id = _.Id,
                Name = _.Name
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
}