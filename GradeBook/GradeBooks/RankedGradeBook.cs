using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            var countOfStudentsWithHigherAverageGrade = Students.Count(s => s.AverageGrade > averageGrade);
            double percentOfHigherAverageGrade = countOfStudentsWithHigherAverageGrade / Students.Count;
            if (percentOfHigherAverageGrade < 0.2)
            {
                return 'A';
            }
            return 'F';
        }
    }
}
