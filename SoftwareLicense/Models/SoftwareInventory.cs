using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    public partial class SoftwareInventory
    {
        [StringLength(255)]
        public string Application { get; set; }
        [StringLength(255)]
        public string ReferenceNumber { get; set; }
        [StringLength(255)]
        public string ComputerName { get; set; }
    }
}
