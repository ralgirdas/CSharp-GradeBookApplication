using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            var countOfStudentsWithHigherAverageGrade = Students.Count(s => s.AverageGrade > averageGrade);
            var percentOfHigherAverageGrade = (double)countOfStudentsWithHigherAverageGrade / (double)Students.Count;
            if (percentOfHigherAverageGrade < 0.2)
            {
                return 'A';
            }

            if (percentOfHigherAverageGrade < 0.4)
            {
                return 'B';
            }

            if (percentOfHigherAverageGrade < 0.6)
            {
                return 'C';
            }

            if (percentOfHigherAverageGrade < 0.8)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count(s => s.Grades.Count > 0) < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
