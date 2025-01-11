using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public string Supplier { get; set; } = null!;

    public DateOnly PurchaseDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
