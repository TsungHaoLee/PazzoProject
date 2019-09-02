namespace Pazzo.Exam
{
    using Pazzo.DB;
    using Pazzo.Exam.ViewModel;
    using System.Collections.Generic;

    public interface IExamService
    {
        List<User> SortExamResult(List<ExamResult> result);
    }
}
