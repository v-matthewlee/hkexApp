using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    public partial class MatchingTable
    {
        [Required]
        public string SoftwareName { get; set; }
        [Required]
        public string LicenseName { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}
