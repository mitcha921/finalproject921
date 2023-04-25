using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using finalproject921.Models;
using finalproject921.Models.ViewModels;

namespace finalproject921.Controllers
{
    public class HomeController : Controller
    {
        private IWaterProjectRepository repo;

        public HomeController (IWaterProjectRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .OrderBy(p => p.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Projects.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        public IActionResult Table()
        {

            var projectsList = repo.Projects.ToList();

            return View(projectsList);
        }

        [HttpGet]
        public IActionResult AddData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData(Project p)
        {
            if (ModelState.IsValid)
            {
                repo.SaveData(p);
                return View("Confirmation");
            }
            else return View();
            
        }

        [HttpGet]
        public IActionResult Edit(int projectid)
        {
            var project = repo.Projects.Single(x=>x.ProjectId == projectid);

            return View("AddData", project);
        }

        [HttpPost]
        public IActionResult Edit(Project p)
        {
                repo.UpdateData(p);
                return RedirectToAction("Table");
            
        }

        [HttpGet]
        public IActionResult Delete(int projectid)
        {
            var project = repo.Projects.Single(x => x.ProjectId == projectid);
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Project p)
        {
            repo.DeleteData(p);
            return RedirectToAction("Table");
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

