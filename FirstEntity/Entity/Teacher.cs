using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Teacher
{
    [Key]
    public int Id { get; set; }

    public DateTime HireDate { get; set; }

    [ForeignKey("Person")]
    public int PersonId { get; set; }

    public Person Person { get; set; }

    [ForeignKey("Subject")]
    public int? SubjectId { get; set; }

    public Subject Subject { get; set; }
}

