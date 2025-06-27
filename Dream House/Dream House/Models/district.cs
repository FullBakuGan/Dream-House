using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;

public partial class district
{

    public int id { get; set; }

    public string district_name { get; set; } = null!;

    public virtual ICollection<ad> ads { get; set; } = new List<ad>();
}
