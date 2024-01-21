using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class Medicine
    {
        [Required, Key]
        public int MedicineId { get; set; }
        [MaxLength(50)]
        public string MedicineName { get; set; }
        [MaxLength(5)]
        public bool MedicineIsAvailable { get; set; }
        public DateTime MedicineExpireDate { get; set; }
         public ICollection<Relative> relatives { get; set; }
        public List<RelativeMedicine> RelativeMedicines { get; set; }
    }
    public class RelativeMedicine
    {
        public int RelativeSsn { get; set; }
        public Relative Relative { get; set; }
        public int MedicineId { get; set; }
        public Medicine medicine { get; set; }
       
    }
}
