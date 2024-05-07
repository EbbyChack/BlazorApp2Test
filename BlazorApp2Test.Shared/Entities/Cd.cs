using System;
using System.Collections.Generic;

namespace BlazorApp2Test.Shared.Entities;

public partial class Cd
{
    public int IdCd { get; set; }

    public string NameCd { get; set; } = null!;

    public DateOnly DateReleased { get; set; }

    public decimal Price { get; set; }

    public string Artist { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<OrderCd> OrderCds { get; set; } = new List<OrderCd>();
}
