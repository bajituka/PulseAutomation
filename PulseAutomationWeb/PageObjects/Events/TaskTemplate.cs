namespace PulseAutomationWeb.PageObjects.Events
{
    class TaskTemplate
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public TaskTemplate(string title, string text = null)
        {
            Title = title;
            Text = text;
        }
    }
}
