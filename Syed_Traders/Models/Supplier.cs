using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Email { get; set; } = null!;

    public string Status { get; set; } = null!;
}
