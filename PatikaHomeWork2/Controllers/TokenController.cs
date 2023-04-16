using Company.Api;
using Company.Base;
using Company.Dto;
using Company.Service;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controller;


    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;
        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenManagementService.GenerateToken(request);
            return response;
        }


    }


