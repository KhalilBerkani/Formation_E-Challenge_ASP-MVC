using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Student
{
    [Key]
    public int StudentNumber { get; set; }

    [ForeignKey("Person")]
    public int PersonId { get; set; }

    public Person Person { get; set; }
}

