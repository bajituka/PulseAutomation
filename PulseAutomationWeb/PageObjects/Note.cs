namespace PulseAutomationWeb.PageObjects.ContactsTab.Events
{
    class Note
    {
        public string Priority { get; set; }
        public string Text { get; set; }

        public Note(string priority, string text)
        {
            Priority = priority;
            Text = text;
        }
    }
}
