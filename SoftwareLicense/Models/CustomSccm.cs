using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    [Table("CustomSCCM")]
    public partial class CustomSccm
    {
        [StringLength(255)]
        public string ComputerName { get; set; }
        [StringLength(255)]
        public string SoftwareName { get; set; }
        [StringLength(255)]
        public string SoftwareVersion { get; set; }
    }
}
