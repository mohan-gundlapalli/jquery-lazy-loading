using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LazyLoadingAccounts.Models;
using LazyLoadingAccounts.Repositories;
using LazyLoadingAccounts.DTO;

namespace LazyLoadingAccounts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IAccountRepository _accountRepo;

        private int _pageSize = 10;

        public HomeController(ILogger<HomeController> logger, IAccountRepository ar)
        {
            _logger = logger;
            _accountRepo = ar;
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            try
            {
                // Execute the procedure and get the data.
                var records = await _accountRepo.GetAccounts(1, _pageSize);

                return View(records);
            }
            catch (Exception ex)
            {
                // TODO: Add the exception to logger.
                return View(new List<AccountRoleDTO>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts(int pageNo = 2)
        {

            try
            {
                // Execute the procedure and get the data.
                var records = await _accountRepo.GetAccounts(pageNo, _pageSize);

                return View(records);
            }
            catch (Exception ex)
            {
                // TODO: Add the exception to logger.
                return View(new List<AccountRoleDTO>());
            }
        }
    }
}
