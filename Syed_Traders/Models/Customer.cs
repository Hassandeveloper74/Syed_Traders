using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Customer1 { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Status { get; set; } = null!;
}
