using Microsoft.AspNetCore.Mvc;
using Group2Intex.Models;

namespace Group2Intex.Components
{
    public class ProjectTypesViewComponent :ViewComponent
    {
        private IIntexRepository _waterRepo;

        //Constructor
        public ProjectTypesViewComponent(IIntexRepository temp) 
        {
            _waterRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedProjectType = RouteData?.Values["projectType"];

            var projectTypes = _waterRepo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(projectTypes);
        }
    }
}
