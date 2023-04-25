using System;
using System.Linq;

namespace finalproject921.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Project> Projects { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}

