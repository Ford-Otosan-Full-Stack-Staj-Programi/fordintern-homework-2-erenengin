

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

namespace Company.Api.Controller;

[Route("/api/[controller]")]
[ApiController]

public class AccountController : ControllerBase
{
    private readonly IAccountService service;
    public AccountController(IAccountService service)
    {
        this.service = service;
    }


    [HttpGet]
    [Authorize]
    public BaseResponse<List<AccountDto>> GetAll()
    {
        
        var response = service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    [Authorize]
    public BaseResponse<AccountDto> GetById(int id)
    {

        var response = service.GetById(id);
        return response;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]

    public BaseResponse<bool> Post([FromBody] AccountDto request)
    {
        
        var response = service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    [Authorize]
    public BaseResponse<bool> Put(int id, [FromBody] AccountDto request)
    {
     

        var response = service.Update(id, request);
        return response;
    }





    [HttpDelete]
    [Authorize]
    public BaseResponse<bool> Delete(int id)
    {
       
        var response = service.Delete(id);
        return response;
    }




}

