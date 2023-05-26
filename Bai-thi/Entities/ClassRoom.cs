using System;
using System.Collections.Generic;

namespace Bai_thi.Entities;

public partial class ClassRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AddNewPage> AddNewPages { get; set; } = new List<AddNewPage>();
}
