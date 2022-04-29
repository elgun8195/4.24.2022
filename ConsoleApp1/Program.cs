using ConsoleApp1.Models;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int id;
            Group group = null;
            Student student = null;
            string password;
            string email;
            bool check = true;
            double point;
            string groupno;
            int studentlimit;
            bool dayan = true;

            do
            {
                Console.WriteLine("Passwordu daxil et");
                password = Console.ReadLine();
            } while (!PasswordChecker(password));

            Console.WriteLine("Emaili daxil et");
            email = Console.ReadLine();
            User user = new User(email, password);

            #region ##################################


            Console.WriteLine("Studentin Fullnamesini daxil et");
            string fullname = Console.ReadLine();

            do
            {
                Console.WriteLine("Studentin Pointini daxil et");
                point = Convert.ToDouble(Console.ReadLine());
            } while (point < 0 || point > 100);

            student = new Student(fullname, point);
            #endregion ###################################

            do
            {
                Console.WriteLine("1. ShowInfo");
                Console.WriteLine("2. Create new group");
                Console.WriteLine("3. O birisi menu");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        user.ShowInfo();
                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("GroupNo daxil et");
                            groupno = Console.ReadLine();
                        } while (!Group.CheckGroupNo(groupno));

                        do
                        {
                            Console.WriteLine("Student limiti daxil et");
                            studentlimit = Convert.ToInt32(Console.ReadLine());
                        } while (studentlimit < 5 || studentlimit > 18);

                        group = new Group(groupno, studentlimit);


                        break;

                    case "3":

                        Menu3();

                        break;
                    default:
                        Console.WriteLine("Bele bir sey yoxdu");
                        break;
                }
            } while (check);


        }
        public static bool PasswordChecker(string password)
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

        public static void Menu3()
        {
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1. Show all students");
            Console.WriteLine("2. Get student by id");
            Console.WriteLine("3. Add student");
            Console.WriteLine("0. Quit");
            do
            {
                string sech = Console.ReadLine();
                switch (sech)
                {
                    case "1":
                        group.GetAllStudent();
                        break;
                    case "2":
                        id = Convert.ToInt32(Console.ReadLine());
                        group.GetStudentByid(id);
                        break;
                    case "3":
                        group.AddStudent(student);
                        break;
                    case "4":
                        dayan = false;
                        break;
                    default:
                        break;
                }
            } while (dayan);
        }
    }
}
