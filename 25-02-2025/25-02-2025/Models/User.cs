﻿using System;
using System.Collections.Generic;

namespace _25_02_2025.Models;

public partial class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? RoleType { get; set; }
}
