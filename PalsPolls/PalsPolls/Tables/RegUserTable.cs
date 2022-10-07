using System;
namespace PalsPolls.Tables
{
    public class RegUserTable
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Guid getUserId()
        {
            return UserId;
        }

        public String getUserName()
        {
            return UserName;
        }

        public String getPassword()
        {
            return Password;
        }

        public String getEmail()
        {
            return Email;
        }

        public String getPhoneNumber()
        {
            return PhoneNumber;
        }

    }



}

