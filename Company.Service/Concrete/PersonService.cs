using AutoMapper;
using Company.Base;
using Company.Data;
using Company.Dto;


namespace Company.Service;

public class PersonService : BaseService<PersonDto, Person>, IPersonService
{
    private readonly IGenericRepository<Person> genericRepository;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public PersonService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Person> genericRepository) : base(unitOfWork, mapper, genericRepository)
    {
        this.unitOfWork = unitOfWork;
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

    public BaseResponse<List<PersonDto>> FilterByAccountId(int id)
    {
      
            var persons = genericRepository.GetAll().Where(x => x.AccountId == id).ToList();
            var mapped = mapper.Map<List<Person>, List<PersonDto>>(persons);
            return new BaseResponse<List<PersonDto>>(mapped);
        
    }

    public BaseResponse<PersonDto> GetPersonById(int accountId, int id)
    {

        var persons = genericRepository.GetAll().Where(x => x.AccountId == accountId).ToList();
        var person = persons.Where(x => x.Id == id).ToList();


        var mapped = mapper.Map<List<Person>, List<PersonDto>>(person).FirstOrDefault();

        return new BaseResponse<PersonDto>(mapped);

    }
}
