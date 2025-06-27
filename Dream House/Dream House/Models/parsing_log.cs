using System;
using System.Collections.Generic;

namespace hackaton_asp_project.Models;

public partial class parsing_log
{

    public int id { get; set; }

    public int id_source { get; set; }

    public DateTime start_time { get; set; }

    public DateTime? end_time { get; set; }


    public string status { get; set; } = null!;

    public string? error_msg { get; set; }
    public int? added_record { get; set; }

    public int? update_record { get; set; }

    public int? deleted_record { get; set; }

    public virtual source id_sourceNavigation { get; set; } = null!;
}
