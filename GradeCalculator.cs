using System;
using System.Collections.Generic;

namespace GradeCalculator
{
    public class Grade
    {
        public static float Average(Dictionary<string, float> subjectGrade)
        {
            float total = 0;
            foreach (string subject in subjectGrade.Keys)
            {
                total += subjectGrade[subject];
            }
            return total / subjectGrade.Count;
        }

        public static void Calculate()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the total number of subjects:");
            int totalSubject = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, float> subjectGrade = new Dictionary<string, float>();

            for (int i = 0; i < totalSubject; i++)
            {
                Console.Write("Name of subject: ");
                string subject = Console.ReadLine();

                Console.Write("Grade value: ");
                float value = float.Parse(Console.ReadLine());

                subjectGrade.Add(subject, value);
            }

            foreach (string subject in subjectGrade.Keys)
            {
                Console.WriteLine($"{subject} : {subjectGrade[subject]}");
            }
            Console.WriteLine($"The average is: {Average(subjectGrade)}");
        }
    }
}
