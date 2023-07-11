
using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

public interface ComplexRepository
{
    void Add(Complex complex);
    List<GetAllComplexDto> GetAll(string? searchName);
    bool IsExistsById(int id);
    int GetUnitCountById(int id);
    List<GetAllUsageTypeByComplexId> GetAllUsageTypeByComplexId(int id);
    GetOneComplexDto GetOneComplexDto(int complexId);
    List<GetAllComplexWithBlookDto> GetAllComplexWithBlooks();
}