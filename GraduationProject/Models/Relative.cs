using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class Relative
    {
        [Required, MaxLength(14), Key]
        public int RelativeSsn { get; set; }
        [MaxLength(50)]
        public string RelativeName { get; set; }
        [MaxLength(11)]
        public int RelativePhone { get; set; }
        [MaxLength(50)]
        public string DegreeOfKinShip { get; set;}
        public DateTime AddedOn { get; set; }

        public string AdminSsn { get; set; }
        public Hospital_Admin hospital_Admins { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
        public List<RelativeMedicine> RelativeMedicines { get; set; }
    }
}
