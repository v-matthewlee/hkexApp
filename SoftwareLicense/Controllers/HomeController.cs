using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SoftwareLicense.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareLicense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HKEX_InventoryContext _context;
        private IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, HKEX_InventoryContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public async Task<IActionResult> QueryDiscrepancy()
        {
            var list = new List<SoftwareLicenseDiscrepancy>();
            string conString = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(conString))
            using (var command = new SqlCommand("GetSoftwareLicenseDiscrepancy", con)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.CommandTimeout = 600;
                await con.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new SoftwareLicenseDiscrepancy()
                        {
                            ComputerName = await reader.GetFieldValueAsync<string>(0),
                            SoftwareName = await reader.GetFieldValueAsync<string>(1),
                        });
                    }
                }
                await con.CloseAsync();
            }
            return View(list);
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
    }
}
