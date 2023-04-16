using AutoMapper;
using Company.Base;
using Company.Data;
using Company.Dto;

using Company.Service;

namespace Company.Service;

public class AccountService : BaseService<AccountDto, Account>, IAccountService
{
    private readonly IGenericRepository<Account> genericRepository;
    private readonly IMapper mapper;
    public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Account> genericRepository) : base(unitOfWork, mapper, genericRepository)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

  
}
