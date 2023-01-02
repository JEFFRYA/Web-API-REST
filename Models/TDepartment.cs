using System;
using System.Collections.Generic;

namespace WebAPI_CRUD.Models;

public partial class TDepartment
{
    public long IdTDepartment { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? Name { get; set; }

    public bool? State { get; set; }
}
