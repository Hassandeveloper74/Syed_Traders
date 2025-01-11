using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class PurchaseDetail
{
    public int PdetailId { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public int CostPrice { get; set; }

    public int Quantity { get; set; }

    public int TotalCost { get; set; }

    public string Status { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
