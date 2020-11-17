using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyLoadingAccounts.DTO;
using LazyLoadingAccounts.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LazyLoadingAccounts.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private IAccountRepository _accountRepo;
        public AccountApiController(IAccountRepository ar) => _accountRepo = ar;

        [HttpGet]
        public async Task<ApiResult> Index(int pageNo, int pageSize = 10)
        {

            try
            {
                // Execute the procedure and get the data.
                var records = await _accountRepo.GetAccounts(pageNo, pageSize);

                var result = new ApiResult { Success = true, Data = records };

                return result;
            }
            catch (Exception ex)
            {
                // TODO: Add the exception to logger.
                return new ApiResult { Success = false, Data = null, Message = $"Api error: {ex.Message}" };
            }
        }
        
    }
}
