using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEntity.Entity.Views
{
    public class TeacherSubjectView
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
    }
}
