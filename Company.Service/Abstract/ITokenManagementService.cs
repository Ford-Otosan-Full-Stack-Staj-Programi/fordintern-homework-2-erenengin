using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Base;
using Company.Dto;

namespace Company.Service
{
    
        public interface ITokenManagementService
        {
            BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
        }
    
}
