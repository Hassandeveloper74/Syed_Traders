using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public int CostPrice { get; set; }

    public int SellingPrice { get; set; }

    public int MinimumStock { get; set; }

    public string Unit { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Accounting> Accountings { get; set; } = new List<Accounting>();

    public virtual ProductsCategory Category { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
