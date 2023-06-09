using System;
using System.Collections.Generic;

namespace Domain
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsCancelled { get; set; }

        public ICollection<AssignmentAttendee> Attendees { get; set; } = new List<AssignmentAttendee>();
    }
}