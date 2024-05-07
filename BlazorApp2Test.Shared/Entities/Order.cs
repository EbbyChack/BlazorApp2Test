using System;
using System.Collections.Generic;

namespace BlazorApp2Test.Shared.Entities;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateOnly DateOrdered { get; set; }

    public string Address { get; set; } = null!;

    public decimal Total { get; set; }

    public int FkUserId { get; set; }

    public virtual User FkUser { get; set; } = null!;

    public virtual ICollection<OrderCd> OrderCds { get; set; } = new List<OrderCd>();
}
