using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class Hospital_Admin
    {
        [Required,MaxLength(14),Key]
        public string AdminSsn {  get; set; }
        [MaxLength(50)]
        public string AdminName { get; set; }
        [MaxLength(30)]
        public string AdminCity { get; set; }
        [MaxLength(50)]
        public string AdminStreet { get; set; }
        public int AdminZipCode { get; set; }
        [MaxLength(11)]
        public string AdminPhone { get; set; }
        public DateTime AdminBirthDate { get; set; }
        public ICollection<Patient> patients { get; set; }
        public ICollection<Relative> relatives { get; set; }

    }
}
