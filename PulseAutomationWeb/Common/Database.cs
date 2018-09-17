using System.Configuration;
using System.Data.SqlClient;

namespace PulseAutomationWeb.Common
{
    class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Pulse"].ConnectionString;

        private static int GetCount(string query, string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int count = (int)command.ExecuteScalar();
            connection.Close();
            return count;
        }

        public static int GetPersonsCount(string firstName)
        {
            string checkForPersonsExisting = string.Format("SELECT COUNT(*) FROM dbo.Contacts WHERE FirstName = '{0}' AND DeletedAt IS NULL", firstName);
            return GetCount(checkForPersonsExisting, firstName);
        }

        public static int GetCompaniesCount(string companyName)
        {
            string checkForCompaniesExisting = string.Format("SELECT COUNT(*) FROM dbo.Contacts WHERE Name = '{0}' AND DeletedAt IS NULL", companyName);
            return GetCount(checkForCompaniesExisting, companyName);
        }

        public static int GetFiltersViewCount(string templateName)
        {
            string checkForFilterViewsExisting = string.Format("SELECT COUNT(*) FROM dbo.GridSessions WHERE TemplateName = '{0}' AND UserId in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = 'script@gmail.com')", templateName);
            return GetCount(checkForFilterViewsExisting, templateName);
        }

        public static int GetTasksCount(string author)
        {
            string checkForTasksCount = string.Format("SELECT COUNT(*) FROM dbo.Tasks WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = '{0}')", author);
            return GetCount(checkForTasksCount, author);
        }

        public static int GetActivitiesCount(string author)
        {
            string checkForTasksCount = string.Format("SELECT COUNT(*) FROM dbo.Activities WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = '{0}')", author);
            return GetCount(checkForTasksCount, author);
        }

        public static int GetNotesCount(string author)
        {
            string checkForNotesCount = string.Format("SELECT COUNT(*) FROM dbo.Notes WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = '{0}')", author);
            return GetCount(checkForNotesCount, author);
        }

        public static int GetTaskTemplatesCount(string author)
        {
            string checkForTaskTemplatesCount = string.Format("SELECT COUNT(*) FROM dbo.TasksTemplates WHERE CreatedById in (SELECT Id FROM dbo.AspNetUsers WHERE UserName = '{0}')", author);
            return GetCount(checkForTaskTemplatesCount, author);
        }

        public static void ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void ExecuteDeleteAppointment()
        {
            string today = Utilities.CurrentDateSql();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Appointments (MeetingSubject, StartOn, EndOn, CreatedById, CreatedAt, VenueId, AppearanceTypeId, AppointmentTypeId, OfficeId, AppearingAttorneyId, MatterId, UpdatedById, UpdatedAt, FromTaskId) VALUES('TestQA Meeting to Delete', @TODAY, @TODAY, 'AFB8397F-3514-4DE9-9704-7B00B36F237E', '2017-08-15 08:01:41.873', null, null, null, null, null, null, 'AFB8397F-3514-4DE9-9704-7B00B36F237E', '2017-08-15 08:09:41.873', null)", connection);
            command.Parameters.AddWithValue("@TODAY", today);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void ExecuteUpdateAppointment()
        {
            string today = Utilities.CurrentDateSql();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Appointments (MeetingSubject, StartOn, EndOn, CreatedById, CreatedAt, VenueId, AppearanceTypeId, AppointmentTypeId, OfficeId, AppearingAttorneyId, MatterId, UpdatedById, UpdatedAt, FromTaskId) VALUES('TestQA Meeting to Update', @TODAY, @TODAY, 'AFB8397F-3514-4DE9-9704-7B00B36F237E', '2017-08-15 08:01:41.873', null, null, null, null, null, null, 'AFB8397F-3514-4DE9-9704-7B00B36F237E', '2017-08-15 08:09:41.873', null)", connection);
            command.Parameters.AddWithValue("@TODAY", today);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
