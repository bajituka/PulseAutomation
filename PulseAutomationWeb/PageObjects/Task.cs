namespace PulseAutomationWeb.PageObjects.ContactsTab.Events
{
    class Task
    {
        public string Title { get; set; }
        public string TaskType { get; set; }
        public string Status { get; set; }
        public string ClientContact { get; set; }
        public string Matter { get; set; }
        public string Assignee{ get; set; }
        public string Assignor { get; set; }
        public string DueDate { get; set; }
        public string ReminderDays { get; set; }
        public string Importance { get; set; }
        public string DependentTask { get; set; }
        public string Text { get; set; }

        public Task(string title, string assignee, string taskType,  string status = null, string clientContact = null, string matter = null, string assignor= null, string dueDate = null, string reminderDays = null, string importance = null, string dependentTask = null, string text = null)
        {
            Title = title;
            Assignee = assignee;
            TaskType = taskType;
            Status = status;
            ClientContact = clientContact;
            Matter = matter;
            Assignor = assignor;
            DueDate = dueDate;
            ReminderDays = reminderDays;
            Importance = importance;
            DependentTask = dependentTask;
            Text = text;
        }
    }
}
