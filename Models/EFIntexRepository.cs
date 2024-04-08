namespace Group2Intex.Models
{
    public class EFIntexRepository : IIntexRepository
    {
        //private IntexContext _context;
        /*        public EFIntexRepository(IntexContext temp) 
                {
                    _context = temp;
                }*/
        private readonly List<Project> _projects = new List<Project>();

        public EFIntexRepository()
        {
            // Add dummy data
            _projects.Add(new Project
            {
                ProjectId = 1,
                ProjectName = "Project 1",
                ProgramName = "Program A",
                ProjectType = "Type A",
                ProjectImpact = 10,
                ProjectInstallation = DateTime.Now,
                ProjectPhase = "Phase 1"
            });

            _projects.Add(new Project
            {
                ProjectId = 2,
                ProjectName = "Project 2",
                ProgramName = "Program B",
                ProjectType = "Type B",
                ProjectImpact = 20,
                ProjectInstallation = DateTime.Now.AddDays(1),
                ProjectPhase = "Phase 2"
            });
        }

        public IQueryable<Project> Projects => _projects.AsQueryable();

        //public IQueryable<Project> Projects => _context.Projects;
    }
}
