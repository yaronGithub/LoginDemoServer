﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoginDemoServer.Models;

public partial class User
{
    [Key]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Password { get; set; } = null!;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    public int? Status { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("StudentEmailNavigation")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
