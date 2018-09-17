namespace PulseAutomationWeb.PageObjects.Calendar
{
    class Appointment
    { 
        public string Recipients { get; set; }
        public string AppearingAttorney { get; set; }
        public string MeetingSubject { get; set; }
        public string ClientContact { get; set; }
        public string Matter { get; set; }
        public string AppointmentType { get; set; }
        public string AppearanceType { get; set; }
        public string Venue { get; set; }
        public string Office { get; set; }
        public string StartOn { get; set; }
        public string EndOn { get; set; }
        public string DueDate { get; set; }
        public string Comments { get; set; }
        public string Repeat { get; set; }
        public string Reminder { get; set; }
        public string Category { get; set; }

        public Appointment(string meetingSubject, string appearanceType, string venue, string recipients = null, string appearingAttorney = null, string clientContact = null, string matter = null, string appointmentType = null, string office = null, string startOn = null, string endOn = null, string dueDate = null, string comments = null, string repeat= null, string reminder = null, string category = null)
            {
                Recipients = recipients;
                AppearingAttorney = appearingAttorney;
                MeetingSubject = meetingSubject;
                ClientContact = clientContact;
                Matter = matter;
                AppointmentType = appointmentType;
                AppearanceType = appearanceType;
                Venue = venue;
                Office = office;
                StartOn = startOn;
                EndOn = endOn;
                DueDate = dueDate;
                Comments = comments;
                Repeat = repeat;
                Reminder = reminder;
                Category = category;
            }
    }
}
