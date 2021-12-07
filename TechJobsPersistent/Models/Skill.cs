using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.Models
{
    public class Skill
    {
        [Key]
        public int SkillsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Skill()
        {
        }

        public Skill(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
