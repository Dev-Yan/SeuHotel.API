namespace Shared.Core.Classes.Interfaces;

public interface IService<DTO>
{
    Task<DTO> GetOne(long id);
    Task<List<DTO>> GetAll();
    Task<DTO> Create(DTO dto);
    Task<DTO> Update(long? id, DTO dto);
    Task Delete(long id);
}