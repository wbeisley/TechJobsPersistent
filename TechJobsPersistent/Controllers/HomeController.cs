using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Job.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> employers = context.Employers.ToList();
            List<Skill> skills = context.Skills.ToList();
            AddJobViewModel viewModel = new AddJobViewModel(employers, skills);
            return View(viewModel);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel viewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {

                Job job = new Job
                {
                    Name = viewModel.Name,
                    EmployerId = viewModel.EmployerId,
                    Employer = context.Employers.Find(viewModel.Employers)
                };

                foreach (var skill in selectedSkills)
                {
                    JobSkill jobSkill = new JobSkill
                    {
                        Job = job,
                        SkillId = int.Parse(skill)
                    };

                    context.JobSkills.Add(jobSkill);
                }
                    
                    context.Job.Add(job);
                    context.SaveChanges();
               

                return Redirect("Index");
            }

            return View("Add", viewModel);

        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Job
                .Include(j => j.Employer)
                .Single(j => j.JobsId == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
