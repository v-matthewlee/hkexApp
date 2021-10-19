﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    public partial class Softwares
    {
        [Required]
        public string Name { get; set; }
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
