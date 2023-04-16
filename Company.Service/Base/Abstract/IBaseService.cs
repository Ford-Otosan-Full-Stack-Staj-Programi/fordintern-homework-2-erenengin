using Company.Base;

namespace Company.Service;

public interface IBaseService<Dto,TEntity>
{
    BaseResponse<Dto> GetById(int id);
    BaseResponse<List<Dto>> GetAll();
    BaseResponse<bool> Insert(Dto insertResource);
    BaseResponse<bool> Update(int id, Dto updateResource);
    BaseResponse<bool> Delete(int id);
}
