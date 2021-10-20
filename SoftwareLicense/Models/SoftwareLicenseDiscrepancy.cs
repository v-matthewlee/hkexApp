using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareLicense.Models
{
    public class SoftwareLicenseDiscrepancy
    {
        [StringLength(255)]
        public string ComputerName { get; set; }
        [StringLength(255)]
        public string SoftwareName { get; set; }
    }
}
