using ClosedXML.Excel;
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
using System.Reflection;
using System.Threading.Tasks;

namespace SoftwareLicense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HKEX_InventoryContext _context;
        private IConfiguration _configuration;
        private List<SoftwareLicenseDiscrepancy> _softwareLicenseDiscrepancyList;
        public HomeController(ILogger<HomeController> logger, HKEX_InventoryContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
            _softwareLicenseDiscrepancyList = new List<SoftwareLicenseDiscrepancy>();
        }

        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public async Task<IActionResult> QueryDiscrepancy(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            
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
                            _softwareLicenseDiscrepancyList.Add(new SoftwareLicenseDiscrepancy()
                            {
                                ComputerName = await reader.GetFieldValueAsync<string>(0),
                                SoftwareName = await reader.GetFieldValueAsync<string>(1),
                            });
                        }
                    }
                    await con.CloseAsync();
                }

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Data_Test_Worksheet");
            

            PropertyInfo[] properties = _softwareLicenseDiscrepancyList.First().GetType().GetProperties();
            List<string> headerNames = properties.Select(prop => prop.Name).ToList();
            for (int i = 0; i < headerNames.Count; i++)
            {
                ws.Cell(1, i + 1).Value = headerNames[i];
            }

            ws.Cell(2, 1).InsertData(_softwareLicenseDiscrepancyList);
            wb.SaveAs("Reports/QueryDiscrepancy.xlsx");

            return View(_softwareLicenseDiscrepancyList);
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
