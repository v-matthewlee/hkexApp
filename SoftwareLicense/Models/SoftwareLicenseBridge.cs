using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    public partial class SoftwareLicenseBridge
    {
        [Required]
        public string SoftwareName { get; set; }
        [Required]
        public string LicenseName { get; set; }
        [Column("SoftwareFK")]
        public int SoftwareFk { get; set; }
        [Column("LicenseFK")]
        public int LicenseFk { get; set; }

        [ForeignKey(nameof(LicenseFk))]
        public virtual Licenses LicenseFkNavigation { get; set; }
        [ForeignKey(nameof(SoftwareFk))]
        public virtual Softwares SoftwareFkNavigation { get; set; }
    }
}
