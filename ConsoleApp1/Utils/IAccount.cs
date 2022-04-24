using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Utils
{
    interface IAccount
    {
        public bool PasswordChecker(string password);
        public void ShowInfo();
    }
}
