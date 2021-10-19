using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    [Table("SAMLiteInv")]
    public partial class SamliteInv
    {
        [StringLength(50)]
        public string ComputerName { get; set; }
        public string SoftwareName { get; set; }
        [StringLength(50)]
        public string SoftwareVersion { get; set; }
    }
}
