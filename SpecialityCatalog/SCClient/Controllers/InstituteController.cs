using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SCClient.Models;
using SCClient.Models.Config;
using SCData.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using SCClient.Services;

namespace SCClient.Controllers
{
    public class InstituteController : Controller
    {
        private readonly ILogger<InstituteController> _logger;

        private readonly SpecialityCatalogService _specialityCatalogService;

        public InstituteController(ILogger<InstituteController> logger, SpecialityCatalogService specialityCatalogService)
        {
            _logger = logger;
            _specialityCatalogService= specialityCatalogService;
        }

        public async Task <IActionResult> Index()
        {
            List<Institute> institutes = await _specialityCatalogService.GetInstitutes();
            return View(institutes);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _specialityCatalogService.RemoveInstitute(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Institute institute)
        {
            bool result = await _specialityCatalogService.EditInstitute(institute);   
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(institute);
        }

        [HttpGet] 
        public async Task<IActionResult> Edit(int id)
        {
            var institute = await _specialityCatalogService.GetInstitute(id);
            if (institute == null)
            {
                return RedirectToAction("Index");
            }
            return View(institute);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Institute institute)
        {
           bool result = await _specialityCatalogService.AddInstitute(institute);
           if (result)
           {
                return RedirectToAction(nameof(Index));
           }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}