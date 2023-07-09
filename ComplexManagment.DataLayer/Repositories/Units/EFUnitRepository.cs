namespace ComplexManagment.DataLayer.Repositories.Units;

public class EFUnitRepository : UnitRepository
{
    private readonly EFDataContext _context;

    public EFUnitRepository(EFDataContext context)
    {
        _context = context;
    }
    
    public bool IsExistsByBlockId(int blockId)
    {
        return _context.Units.Any(_ => _.BlookId == blockId);
    }
}