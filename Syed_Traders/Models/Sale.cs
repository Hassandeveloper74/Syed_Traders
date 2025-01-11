using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Sale
{
    public int OrderId { get; set; }

    public DateOnly SaleDate { get; set; }

    public int CustomerName { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
