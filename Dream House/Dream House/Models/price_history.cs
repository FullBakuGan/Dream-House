using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;

public partial class price_history
{

    public int id { get; set; }

    public int id_ad { get; set; }


    public decimal price { get; set; }

    public DateTime? change_date { get; set; }

    public virtual ad id_adNavigation { get; set; } = null!;
}
