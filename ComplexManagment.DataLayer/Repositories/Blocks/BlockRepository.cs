using ComplexManagment.DataLayer.Dto.Blocks;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Blocks;

public interface BlockRepository
{
    bool IsDuplicateNameByComplexId(string name,int complexId);
    int GetTotalUnitCountByComplexId(int complexId);
    int GetTotalUnitCountByComplexIdWithOutThisBlockId(int id,int complexId);
    void Add(Blook blook);
    Blook? FindById(int id);
    bool IsDuplicateNameByComplexId(int id, string name, int complexId);
    void Update(Blook blook);
    int blockUnitCount(int blockId);   
    List<GetAllBlooksDto> GetAllBlooks();
    bool IsExistsByBlockId(int blockId);
    GetOneBlookDto GetOneBlookById(int blockId);
}