using System;
using System.Collections.Generic;

namespace _23_02_2025.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public int? EmployeeCount { get; set; }

    public string? Email { get; set; }
}
