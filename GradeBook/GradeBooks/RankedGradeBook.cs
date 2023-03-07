using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            int howManyBetter = 0;
            foreach (var Student in Students)
                if (averageGrade < Student.AverageGrade) howManyBetter++;

            int percent = (100 * howManyBetter) / Students.Count;

            if (percent < 20) return 'A';
            if (percent < 40) return 'B';
            if (percent < 60) return 'C';
            if (percent < 80) return 'D';
            return 'F';
        }
    }
}
