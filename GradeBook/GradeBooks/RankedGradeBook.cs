using System;

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
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");

            int tally = 0;
            foreach (var student in Students)
            {
                if (averageGrade >= student.AverageGrade)
                    tally++;
            }

            double percent = 100.0 * tally / Students.Count;

            switch (percent)
            {
                case double value when (value > 80):
                    return 'A';
                case double value when (value > 60):
                    return 'B';
                case double value when (value > 40):
                    return 'C';
                case double value when (value > 20):
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}
