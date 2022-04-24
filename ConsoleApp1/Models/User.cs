using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    class User : IAccount
    {
        private static int _id;
        private string _password;
        public int Id { get; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password
        {
            get { return _password; }
            set {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
            }
        }


        public User(string email, string password)
        {
            Id = ++_id;
            Email = email;
            Password = password;
        }      

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} - Fullname: {Fullname} - Email: {Email}");
        }


        public  bool PasswordChecker(string password)
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            if (string.IsNullOrWhiteSpace(password) == false && password.Length >= 8)
            {
                foreach (var item in password)
                {
                    if (char.IsDigit(item))
                        hasDigit = true;

                    if (char.IsLower(item))
                        hasLower = true;

                    if (char.IsUpper(item))
                        hasUpper = true;

                    if (hasDigit && hasUpper && hasLower)
                        return true;
                }
            }
            return false;
        }
    }
}
