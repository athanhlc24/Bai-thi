using System;
using System.Collections.Generic;

namespace Bai_thi.Entities;

public partial class AddNewPage
{
    public int Id { get; set; }

    public TimeSpan StartTime { get; set; }

    public DateTime ExamDate { get; set; }

    public int ExamDuration { get; set; }

    public int? ClassRoomId { get; set; }

    public int? SubjectsId { get; set; }

    public int? FacultiesId { get; set; }

    public string? Status { get; set; }

    public virtual ClassRoom? ClassRoom { get; set; }

    public virtual Faculty? Faculties { get; set; }

    public virtual Subject? Subjects { get; set; }
}
