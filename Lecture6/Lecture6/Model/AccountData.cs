using System;

namespace Lecture6
{
    public class AccountData
    {
        private string taxID;
        private string company;
        private string firstName;
        private string lastName;
        private string address1;
        private string address2;
        private string postcode;
        private string city;
        private string country;
        private string state;
        private string email;
        private string phone;
        private string password;

        public AccountData(string taxID, string company, string firstName, string lastName, 
                           string address1, string address2, string postcode, string city,
                           string country, string state, string email, string phone, string password)
        {
            this.taxID = taxID;
            this.company = company;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address1 = address1;
            this.address2 = address2;
            this.postcode = postcode;
            this.city = city;
            this.country = country;
            this.state = state;
            this.email = RandomizeEmail(email);
            this.phone = phone;
            this.password = password;
        }

        public string TaxID
        {
            get
            {
                return taxID;
            }
            set
            {
                taxID = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                postcode = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string RandomizeEmail(string email)
        {
            int index = new Random().Next() % 1000;
            return email.Insert(email.IndexOf("@"),index.ToString());
        }
    }
}
