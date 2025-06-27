using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;

public partial class source
{

    public int id { get; set; }

    public string source_name { get; set; } = null!;

    public string url { get; set; } = null!;

 
    public DateTime? last_parsing_date { get; set; }

    public virtual ICollection<ad> ads { get; set; } = new List<ad>();

    public virtual ICollection<parsing_log> parsing_logs { get; set; } = new List<parsing_log>();
}
