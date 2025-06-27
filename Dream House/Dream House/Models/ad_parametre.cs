using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;


public partial class ad_parametre
{

    public int id { get; set; }


    public int id_ad { get; set; }


    public string param_name { get; set; } = null!;


    public string value_param { get; set; } = null!;

    public virtual ad id_adNavigation { get; set; } = null!;
}
