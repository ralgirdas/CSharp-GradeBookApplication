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
            var percentOfHigherAverageGrade = (double)countOfStudentsWithHigherAverageGrade / (double)Students.Count;
            if (percentOfHigherAverageGrade < 0.2)
            {
                return 'A';
            }

            if (percentOfHigherAverageGrade < 0.4)
            {
                return 'B';
            }
            return 'F';
        }
    }
}
