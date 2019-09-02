namespace Pazzo.Exam.ViewModel
{
    using Pazzo.DB;

    public class ExamResult
    {
        public User User { get; set; }
        public double ChineseResult { get; set; }
        public double MathResult { get; set; }
        public double EnglishResult { get; set; }
        public double TotalResult { get; set; }
    }
}
