﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.Models
{
    public class Employer
    {
        [Key]
        public int EmployerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Employer()
        {
        }

        public Employer(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
