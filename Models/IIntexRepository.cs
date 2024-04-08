namespace Group2Intex.Models
{
    public interface IIntexRepository
    {
        public IQueryable<Project> Projects { get; }

    }
}
