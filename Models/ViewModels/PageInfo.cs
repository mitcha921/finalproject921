﻿using System;
namespace finalproject921.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalNumProjects / ProjectsPerPage);
    }
}

