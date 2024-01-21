using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class Patient
    {
        [Required, MaxLength(14), Key]
        public string PatientSsn { get; set; }
        [MaxLength(50)]
        public string PatientName { get; set; }
        [MaxLength(30)]
        public string PatientCity { get; set; }
        [MaxLength(50)]
        public string PatientStreet { get; set; }

        public int PatientZipCode { get; set; }
        [MaxLength(11)]
        public string PatientPhone { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public DateTime MangedOn { get; set; }
        
        public string AdminSsn {  get; set; }
        public Hospital_Admin hospital_Admins { get; set; }
        

    }
}
