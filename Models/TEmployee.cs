using System;
using System.Collections.Generic;

namespace WebAPI_CRUD.Models;

public partial class TEmployee
{
    public long IdTEmployee { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? FullName { get; set; }

    public decimal? Salary { get; set; }

    public long? IdFDepartment { get; set; }

    public virtual TDepartment? IdFDepartmentNavigation { get; set; }
}
