namespace PulseAutomationWeb.PageObjects
{
    class TimeEntry
    { 
        public string EntryDate { get; set; }
        public string TimeKeeper { get; set; }
        public string Client { get; set; }
        public string Matter { get; set; }
        public string ActionCode { get; set; }
        public string TypedBy { get; set; }
        public string Office { get; set; }
        public string BaseHrsMins { get; set; }
        public string Type { get; set; }
        public string Document { get; set; }
        public string Activity { get; set; }
        public string Task { get; set; }
        public string NarrativeText { get; set; }
        public string NoServiceChargeCheckBox { get; set; }
        public string EmailEntryCheckBox { get; set; }
        public string DoNotTransferCheckBox { get; set; }
        public string BriefSubjectMatterCheckBox { get; set; }
        public string BillingCommentsCheckBox { get; set; }
        public string BillingComments { get; set; }

        public TimeEntry(string timeKeeper, string client, string matter, string actionCode,string office, string baseHrsMins, string entryDate = null, string typedBy = null, string type = null, string document = null, string activity = null, string task = null, string narrativeText = null, string noServiceChargeCheckBox = null, string emailEntryCheckBox = null, string doNotTransferCheckBox = null, string briefSubjectMatterCheckBox = null, string billingCommentsCheckBox = null, string billingComments = null)
            {
                EntryDate = entryDate;
                TimeKeeper = timeKeeper;
                Client = client;
                Matter = matter;
                ActionCode = actionCode;
                TypedBy = typedBy;
                Office = office;
                BaseHrsMins = baseHrsMins;
                Type = type;
                Document = document;
                Activity = activity;
                Task = task;
                NarrativeText = narrativeText;
                NoServiceChargeCheckBox = NoServiceChargeCheckBox;
                EmailEntryCheckBox = emailEntryCheckBox;
                DoNotTransferCheckBox = DoNotTransferCheckBox;
                BriefSubjectMatterCheckBox = briefSubjectMatterCheckBox;
                BillingCommentsCheckBox = billingCommentsCheckBox;
                BillingComments = BillingComments;
            }

    }

}
