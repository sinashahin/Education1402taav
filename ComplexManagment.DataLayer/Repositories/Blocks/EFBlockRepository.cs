using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Blocks;

public class EFBlockRepository : BlockRepository
{
    private readonly EFDataContext _context;

    public EFBlockRepository(EFDataContext context)
    {
        _context = context;
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
        _context.SaveChanges();
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
        _context.SaveChanges();
    }
}