using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class SalesOrderDetail
{
    public int SodetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int SellingPrice { get; set; }

    public int Quantity { get; set; }

    public int TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public virtual Sale Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
