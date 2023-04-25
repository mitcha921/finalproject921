using System;
using System.Linq;

namespace finalproject921.Models
{
	public class EFWaterProjectRepository :IWaterProjectRepository
	{
		private WaterProjectContext context { get; set; }

		public EFWaterProjectRepository(WaterProjectContext temp)
		{
			context = temp;
		}

		public IQueryable<Project> Projects => context.Projects;

        public void SaveData(Project project)
        {
			context.Projects.Add(project);
			context.SaveChanges();
        }

        public void UpdateData(Project project)
        {
			context.Projects.Update(project);
			context.SaveChanges();
        }

        public void DeleteData(Project project)
        {
            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }
}

