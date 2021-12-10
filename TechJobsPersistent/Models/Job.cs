using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.Models
{
    public class Job
    {
        [Key]
        public int JobsId { get; set; }

        public string Name { get; set; }

        public Employer Employer { get; set; }

        public int EmployerId { get; set; }

        public List<JobSkill> JobSkills { get; set; }

        public Job()
        {
        }
        public Job(string name, int employerId)
        {
            Name = name;
            EmployerId = employerId;
        }

        public Job(string name)
        {
            Name = name;
        }
    }
}
