using System;
using System.Collections.Generic;

namespace BlazorApp2Test.Shared.Entities;

public partial class OrderCd
{
    public int IdOrderCd { get; set; }

    public int FkIdOrder { get; set; }

    public int FkIdCd { get; set; }

    public virtual Cd FkIdCdNavigation { get; set; } = null!;

    public virtual Order FkIdOrderNavigation { get; set; } = null!;
}
