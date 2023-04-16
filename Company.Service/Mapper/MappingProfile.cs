using AutoMapper;
using Company.Data;
using Company.Dto;

namespace Company.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();

        CreateMap<Account, AccountDto>();
        CreateMap<AccountDto, Account>();


    }
}
