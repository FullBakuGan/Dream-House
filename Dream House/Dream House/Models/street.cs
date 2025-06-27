using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;


public partial class street
{
    public int id { get; set; }


    public string street_name { get; set; } = null!;

    public virtual ICollection<ad> ads { get; set; } = new List<ad>();
}
