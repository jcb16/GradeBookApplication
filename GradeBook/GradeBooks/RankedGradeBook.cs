using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var poziom = (int)Math.Ceiling(Students.Count * 0.2);
            var ocena = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            else
            {
                if (ocena[poziom - 1] <= averageGrade)
                    return 'A';
                else if (ocena[(poziom * 2) - 1] <= averageGrade)

                    return 'B';
                else if (ocena[(poziom * 3) - 1] <= averageGrade)
                    return 'C';
                else if (ocena[(poziom * 4) - 1] <= averageGrade)
                    return 'D';
                else
                    return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}

