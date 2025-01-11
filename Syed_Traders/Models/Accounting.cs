using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Accounting
{
    public int AccountingId { get; set; }

    public int ReferenceId { get; set; }

    public int TransactionType { get; set; }

    public int ProductId { get; set; }

    public int CostPrice { get; set; }

    public int SellingPrice { get; set; }

    public string Status { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
