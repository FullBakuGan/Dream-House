using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;


public partial class status
{

    public int id { get; set; }

    public string status_name { get; set; } = null!;

    public virtual ICollection<ad> ads { get; set; } = new List<ad>();
}
