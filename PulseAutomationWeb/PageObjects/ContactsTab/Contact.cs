namespace PulseAutomationWeb.PageObjects.ContactsTab
{
    abstract class Contact
    {
        public string Twitter { get; set; }
        public string Jurisdiction { get; set; }
        public string ContactRole { get; set; }

        public string LinkedInProfile { get; set; }

        public Contact(string contactRole, string twitter, string linkedin, string jurisdiction)
        {
            ContactRole = contactRole;
            Twitter = twitter;
            LinkedInProfile = linkedin;
            Jurisdiction = jurisdiction;
        }
    }

    class Person : Contact
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Skype { get; set; }
        public string SocialSecurity { get; set; }

        public Person(string firstName, string lastName, string prefix = null, string contactRole = null, string company = null, string position = null, string suffix = null, string middleName = null, string twitter = null, string jurisdiction = null, string skype = null, string linkedin = null, string socialSecurity = null)
            :base(contactRole, twitter, linkedin, jurisdiction)
        {
            Prefix = prefix;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
            Company = company;
            Position = position;
            Skype = skype;
            LinkedInProfile = linkedin;
            SocialSecurity = socialSecurity;
        }
    }

    class Company : Contact
    {
        public string Name { get; set; }
        public string Website { get; set; }

        public Company(string name, string contactRole = null, string twitter = null, string linkedin = null, string jurisdiction = null, string website = null)
            :base(contactRole, twitter, linkedin, jurisdiction)
        {
            Name = name;
            Website = website;
        }
    }

    class Address
    {
        public string AddressType { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Address(string addressType, string zip, string street, string street2, string city, string state)
        {
            AddressType = addressType;
            Zip = zip;
            Street = street;
            Street2 = street2;
            City = city;
            State = state;
        }
    }

    class Phone
    {
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }

        public Phone(string phoneType, string phoneNumber)
        {
            PhoneType = phoneType;
            PhoneNumber = phoneNumber;
        }
    }

    class Email
    {
        public string EmailType { get; set; }
        public string EmailAddress { get; set; }

        public Email(string emailType, string emailAddress)
        {
            EmailType = emailType;
            EmailAddress = emailAddress;
        }
    }
}
