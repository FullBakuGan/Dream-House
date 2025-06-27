using Dream_House.Models;
using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;

public partial class ad
{

    public int id { get; set; }


    public int type_id { get; set; }


    public int source_id { get; set; }

    public int status_id { get; set; }

    public int? district_id { get; set; }

    public int city_id { get; set; }


    public int? city_district_id { get; set; }

    public int? microdistrict_id { get; set; }
    public int? street_id { get; set; }
    public decimal? area_obj { get; set; }
    public decimal? cost { get; set; }
    public string? description { get; set; }

    public string ad_num { get; set; } = null!;
    public int count_of_rooms { get; set; }
    public int stage { get; set; }

    public virtual ICollection<ad_parametre> ad_parametres { get; set; } = new List<ad_parametre>();

    public virtual city city { get; set; } = null!;

    public virtual city_district city_district { get; set; }

    public virtual district district { get; set; }

    public virtual ICollection<favorite> favorites { get; set; } = new List<favorite>();

    public virtual ICollection<image_ad> image_ads { get; set; } = new List<image_ad>();

    public virtual microdistrict microdistrict { get; set; }

    public virtual ICollection<price_history> price_histories { get; set; } = new List<price_history>();

    public virtual source source { get; set; } = null!;

    public virtual status status { get; set; } = null!;

    public virtual street? street { get; set; }

    public virtual type_obj type { get; set; } = null!;
}
