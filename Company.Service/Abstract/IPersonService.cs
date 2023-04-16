using Company.Base;
using Company.Data;
using Company.Dto;


namespace Company.Service;

public interface IPersonService : IBaseService<PersonDto,Person>
{
    BaseResponse<List<PersonDto>> FilterByAccountId(int id);
    BaseResponse<PersonDto> GetPersonById(int accountId, int id);
}
