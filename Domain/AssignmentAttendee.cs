using System;

namespace Domain
{
    public class AssignmentAttendee
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public bool IsHost { get; set; }
    }
}