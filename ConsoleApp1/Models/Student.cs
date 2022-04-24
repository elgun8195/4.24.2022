using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    class Student
    {
        private static int _id;
        private double _point;
        public int Id { get; }
        public string Fullname { get; set; }

        public double Point
        {
            get { return _point; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _point = value;
                }
            }
        }

        public Student(string fullname, double point)
        {
            Id = ++_id;
            Fullname = fullname;
            Point = point;
        }

        public void Showinfo()
        {
            Console.WriteLine($"Id: {Id} - Fullname: {Fullname} - Point: {Point}");
        }

    }
}
