using CollegeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeApp.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students;

        public StudentService()
        {
            _students = CollegeRepository.Students;
        }

        public IEnumerable<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public Student GetByName(string name)
        {
            return _students.FirstOrDefault(s => s.StudentName == name);
        }

        public Student Insert(Student student)
        {
            int newId = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;

            Student newStudent = new Student
            {
                Id = newId,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address
            };

            _students.Add(newStudent);
            return newStudent;
        }

        public void Update(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
            {
                throw new ArgumentException("Student not found.");
            }

            existingStudent.StudentName = student.StudentName;
            existingStudent.Address = student.Address;
            existingStudent.Email = student.Email;
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new ArgumentException("Student not found.");
            }

            _students.Remove(student);
        }
    }
}