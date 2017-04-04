using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        [Required]
        [Display(Name = "Locations")]
        public int LocationID { get; set; }

        [Required]
        [Display(Name = "CoreCompetencies")]
        public int CoreCompetenciesID { get; set; }

        [Required]
        [Display(Name = "PositionTypes")]
        public int PositionTypesID { get; set; }

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetency { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionType { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view

            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach(CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetency.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach(PositionType field in jobData.PositionTypes.ToList())
            {
                PositionType.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
        }
    }
}
