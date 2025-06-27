using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;


public partial class image_ad
{

    public int id { get; set; }


    public int id_ad { get; set; }


    public string url_img { get; set; } = null!;

    public bool? основное { get; set; }

    public virtual ad id_adNavigation { get; set; } = null!;
}
