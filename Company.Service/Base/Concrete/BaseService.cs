using AutoMapper;
using Company.Base;
using Company.Data;
using Serilog;

namespace Company.Service;

public abstract class BaseService<Dto, Tent> : IBaseService<Dto, Tent> where Tent : class 
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IGenericRepository<Tent> genericRepository;

    public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Tent> genericRepository)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.genericRepository = genericRepository;
    }




    public virtual BaseResponse<List<Dto>> GetAll()
    {
        var entityList = genericRepository.GetAll();
        var mapped = mapper.Map<List<Tent>, List<Dto>>(entityList);
        return new BaseResponse<List<Dto>>(mapped);
    }

    public virtual BaseResponse<Dto> GetById(int id)
    {
        var entity = genericRepository.GetById(id);
        var mapped = mapper.Map<Tent, Dto>(entity);
        return new BaseResponse<Dto>(mapped);
    }

    public virtual BaseResponse<bool> Insert(Dto insertResource)
    {
        try
        {
            var entity = mapper.Map<Dto, Tent>(insertResource);

            genericRepository.Insert(entity);
            unitOfWork.Complete();

            return new BaseResponse<bool>(true);
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>("Unexpected Error");
        }
    }

    public virtual BaseResponse<bool> Delete(int id)
    {
        try
        {
            var entity = genericRepository.GetById(id);
            if (entity is null)
            {
                return new BaseResponse<bool>("No_Data");
            }

            genericRepository.Delete(entity);
            unitOfWork.Complete();

            return new BaseResponse<bool>(true);
        }
        catch (Exception ex)
        {
           
            return new BaseResponse<bool>("Unexpected Error");
        }
    }

    public BaseResponse<bool> Update(int id, Dto updateResource)
    {
        try
        {
            var entity = genericRepository.GetById(id);
            if (entity is null)
            {
                return new BaseResponse<bool>("No_Data");
            }

            var mappedEntity = mapper.Map<Dto, Tent>(updateResource);
            mappedEntity.GetType().GetProperty("Id").SetValue(mappedEntity, id);

            genericRepository.Update(mappedEntity);
            unitOfWork.Complete();

            return new BaseResponse<bool>(true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "BaseService_Update");
            return new BaseResponse<bool>(ex.StackTrace);
        }
    }
}
