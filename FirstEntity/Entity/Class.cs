using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Class
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Level { get; set; }

    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }

    public Teacher Teacher { get; set; }
}


