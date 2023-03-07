using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
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
