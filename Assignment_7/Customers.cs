namespace Banking_System_2.Assignment_7
{
    internal class Customers
    {
        int customer_id;
        string first_name;
        string last_name;
        string DOB;
        string email;
        int phone_number;
        string address;

        public Customers(int customerID,string firstName,string lastName,string dob,string userEmail,int phoneNumber,string userAddress) {
            customer_id = customerID;
            first_name = firstName;
            last_name = lastName;
            DOB = dob;
            email = userEmail;
            phone_number = phoneNumber;
            address = userAddress;
        }

        public int CustomerID {
            get
            {
                return customer_id;
            }
            set
            {
                customer_id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }

        public string LastName
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }

        public string Dob
        {
            get
            {
                return DOB;
            }
            set
            {
                DOB = value;
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

        public int PhoneNumber
        {
            get
            {
                return phone_number;
            }
            set
            {
                phone_number = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public override string ToString()
        {
            return $"Customer ID::{CustomerID}\t First Name::{FirstName}\t Last Name::{LastName}\t DOB::{Dob}\t Email::{Email} PhoneNumber::{PhoneNumber} Address::{Address}";
        }
    }
}
