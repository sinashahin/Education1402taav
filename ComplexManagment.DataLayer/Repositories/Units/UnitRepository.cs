using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Units;

public interface UnitRepository
{
    
    bool DuplicateUnitName(string name,int blockId);   
    int totalUnitInBlock(int blockId);
    void Add(Unit unit);
    List<GetAllUnitsDto> GetAllUnits();
}