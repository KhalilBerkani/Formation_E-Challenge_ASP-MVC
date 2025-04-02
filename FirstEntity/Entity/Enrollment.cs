using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Enrollment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }

    [ForeignKey("Class")]
    public int ClassId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public Student Student { get; set; }
    public Class Class { get; set; }
}

