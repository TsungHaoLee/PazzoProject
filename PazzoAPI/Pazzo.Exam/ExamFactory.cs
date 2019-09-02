namespace Pazzo.Exam
{
    public static class ExamFactory
    {
        public static IExamService GetService(ExamCatalog catalog)
        {
            switch (catalog)
            {
                case ExamCatalog.SoldierExam:
                    return new SoldierExamService();
                default:
                    return null;
            }
        }
    }
}
