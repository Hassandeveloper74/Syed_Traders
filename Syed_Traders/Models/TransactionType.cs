using System;
using System.Collections.Generic;

namespace Syed_Traders.Models;

public partial class TransactionType
{
    public int TransactionTypeId { get; set; }

    public string TransactionTypeName { get; set; } = null!;
}
