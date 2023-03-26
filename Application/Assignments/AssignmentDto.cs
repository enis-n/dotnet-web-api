using System;
using System.Collections.Generic;
using Application.Profiles;

namespace Application.Assignments
{
    public class AssignmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string HostUsername { get; set; }
        public bool IsCancelled { get; set; }

        public ICollection<Profile> Attendees { get; set; }
    }
}