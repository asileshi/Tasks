using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public readonly int RollNumber;
        public string Grade { get; set; }

        public Student(string name, int age, int rollNumber, string grade)
        {
            Name = name;
            Age = age;
            RollNumber = rollNumber;
            Grade = grade;
        }
    }

    public class StudentList<T>
    {
        private List<T> students = new List<T>();

        public void AddStudent(T student)
        {
            students.Add(student);
        }

        public T SearchByName(string name)
        {
            return students.FirstOrDefault(student => student is Student studentObj && studentObj.Name == name);
        }

        public T SearchByRollNumber(int rollNumber)
        {
            return students.FirstOrDefault(student => student is Student studentObj && studentObj.RollNumber == rollNumber);
        }

        public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                if (student is Student s)
                {
                    Console.WriteLine($"Name: {s.Name}, Age: {s.Age}, Roll Number: {s.RollNumber}, Grade: {s.Grade}");
                }
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            StudentList<Student> studentList = new StudentList<Student>();

            Student student1 = new Student("Name", 18, 451, "A");
            Student student2 = new Student("Rock", 19, 345, "A");

            studentList.AddStudent(student1);
            studentList.AddStudent(student2);

            await SerializeAsync(studentList);

            StudentList<Student> deserializedList = await DeserializeAsync();

            deserializedList.DisplayAllStudents();



            Student student = deserializedList.SearchByName("Alice");
            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Student RStudent = deserializedList.SearchByRollNumber(522);
            if (RStudent != null)
            {
                Console.WriteLine($"Name: {RStudent.Name}, Age: {RStudent.Age}, Roll Number: {RStudent.RollNumber}, Grade: {RStudent.Grade}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static async Task SerializeAsync(StudentList<Student> studentList)
        {
            string json = JsonSerializer.Serialize(studentList);
            using (StreamWriter writer = new StreamWriter("students.json"))
            {
                await writer.WriteAsync(json);
            }
        }

        static async Task<StudentList<Student>> DeserializeAsync()
        {
            using (StreamReader reader = new StreamReader("students.json"))
            {
                string json = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<StudentList<Student>>(json);
            }
        }
    }
}
