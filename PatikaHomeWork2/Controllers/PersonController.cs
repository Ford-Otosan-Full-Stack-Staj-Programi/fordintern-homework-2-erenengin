using System.Web;


using AutoMapper;
using Company.Base;
using Company.Data;
using Company.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Security.Claims;
using Company.Service;

using static System.Net.Mime.MediaTypeNames;
using Microsoft.Identity.Client;

namespace Company.Api.Controller;


[Route("/api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService service;
    private readonly IGenericRepository<PersonDto> genericRepository;
    private readonly IUnitOfWork unitOfWork;
    public PersonController(IPersonService service)
    {   this.unitOfWork = unitOfWork;
        this.genericRepository = genericRepository;
        this.service = service;
    }



   
    
    [HttpGet]
    [Authorize]

    public BaseResponse<List<PersonDto>> GetAllByAccount()
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "userId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        var response = service.FilterByAccountId(accountId);
        return response;
    }

    [HttpGet("{id}")]
    [Authorize]
    public BaseResponse<PersonDto> GetById(int id)
    {

        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "userId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        var person = service.GetPersonById(accountId, id);
        return person;


    }



    [HttpPost]
    [Authorize]
    public BaseResponse<bool> Post([FromBody] PersonDto request)
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "userId").FirstOrDefault();
        request.AccountId = Int32.Parse(account.Value);
        var response = service.Insert(request);
        return response;
    }


    //ERROR ID CANT TRACKED
    [HttpPut("{id}")]
    [Authorize]
    public BaseResponse<bool> Put(int id,[FromBody] PersonDto request)
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "userId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        
        var person = service.GetPersonById(accountId, id);

        var response = service.Update(id, request);
        return response;
    }

   



    [HttpDelete]
    [Authorize]
    public BaseResponse<bool> Delete(int id)
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "userId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        var person = service.GetPersonById(accountId, id);

        var response = service.Delete(person.Response.Id);
        return response;
    }



}
