using System;
using System.Collections.Generic;

namespace _25_02_2025.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Img { get; set; }

    public string? Title { get; set; }

    public string? ProductDescription { get; set; }

    public double? Price { get; set; }
}
