using Company.Base;
using Company.Data;
using Company.Dto;

namespace Company.Service;

public interface IAccountService : IBaseService<AccountDto,Account>
{
    BaseResponse<AccountDto> GetById(int id);
}
