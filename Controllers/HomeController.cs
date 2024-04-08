using Group2Intex.Models;
using Group2Intex.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Group2Intex.Controllers
{
    public class HomeController : Controller
    {
        private IIntexRepository _repo;

        public HomeController(IIntexRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum, string projectType)
        {

            int pageSize = 5;

            var blah = new ProjectsListViewModel
            {


                Projects = _repo.Projects
                .Where(x => projectType == x.ProjectType || projectType == null)
                .OrderBy(x => x.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    // if project type is null, get a count of all projects, if filtering then only get the count of the filtered projects
                    TotalItems = projectType == null ? _repo.Projects.Count() : _repo.Projects.Where(x => x.ProjectType == projectType).Count()
                },

                CurrentProjectType = projectType
            };

            /*            var projectData = _repo.Projects
                            .OrderBy(x => x.ProjectName)
                            .Skip(pageSize * (pageNum -1))
                            .Take(pageSize);*/

            return View(blah);
        }

/*        public IActionResult Index()
        {
            return View();
        }*/

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
