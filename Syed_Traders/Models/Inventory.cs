using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public DateOnly TransactionDate { get; set; }

    public int TransactionType { get; set; }

    public int QuantityChange { get; set; }

    public int NewQuantityInStock { get; set; }

    public string Status { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
