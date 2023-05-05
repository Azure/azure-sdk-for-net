using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Repository.Model
{
    public class Checklist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<CheckItem>? CheckItems { get; set; }
    }
}
