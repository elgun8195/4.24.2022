using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    class Group
    {
        private int _limit;
        private string _groupno;
        public string GroupNo
        {
            get { return _groupno; }
            set
            {
                if (CheckGroupNo(value))
                {
                    _groupno = value;
                }
            }
        }
        public int StudentLimit
        {
            get { return _limit; }
            set
            {
                if (value >= 5 && value <= 18)
                {
                    _limit = value;
                }
            }
        }

        private Student[] _students = new Student[0];

        public Group(string groupno,int studentlimit)
        {
            StudentLimit = studentlimit;
            GroupNo = groupno;
        }
        public void AddStudent (Student stu)
        {
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = stu;
        }
        public static bool CheckGroupNo(string groupNo)
        {
            if (!string.IsNullOrWhiteSpace(groupNo) && groupNo.Length == 5 && char.IsUpper(groupNo[0]) && char.IsUpper(groupNo[1]))
            {
                for (int i = 2; i < 5; i++)
                {
                    if (char.IsDigit(groupNo[i]) == false)
                        return false;
                }
                return true;
            }
            return false;
        }
        public Student GetStudentByid(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id Null ola bilmez");
            }
            
            foreach (var student in _students)
             {
                 if (student.Id == id)
                     return student;
             }
            
            return null;
        }

        public Student[] GetAllStudent()
        {
            return _students;
        }
    }
}
