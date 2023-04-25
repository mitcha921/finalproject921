using System;
using System.Linq;

namespace finalproject921.Models
{
	public interface IWaterProjectRepository
	{
		IQueryable<Project> Projects { get; }

        void SaveData(Project project);

		void UpdateData(Project project);

		void DeleteData(Project project);
    }

	
}

