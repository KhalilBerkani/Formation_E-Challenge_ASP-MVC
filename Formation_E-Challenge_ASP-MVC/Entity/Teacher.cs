using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


    public class Teacher
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

