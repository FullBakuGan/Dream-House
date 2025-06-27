using Dream_House.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackaton_asp_project.Models;

public partial class favorite
{

    public int id { get; set; }

    public int id_user { get; set; }

    public int id_ad { get; set; }

    public virtual ad id_adNavigation { get; set; } = null!;

    public virtual User id_userNavigation { get; set; } = null!;
}
