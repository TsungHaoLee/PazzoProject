namespace Pazzo.Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Pazzo.DB;
    using Pazzo.Exam.ViewModel;

    public class SoldierExamService : IExamService
    {
        public List<User> SortExamResult(List<ExamResult> result)
        {
            List<User> users = new List<User>();
            if(result == null || result.Count == 0)
            {
                return users;
            }
            Dictionary<Guid, double> userAndTestResult = new Dictionary<Guid, double>();
            result.ForEach(c =>
            {
                var tempTestResult = (c.ChineseResult * 1.5) + c.EnglishResult + c.MathResult;
                c.TotalResult = tempTestResult;
            });
            
            return result.OrderByDescending(c=>c.TotalResult).Select(c=>c.User).ToList();
        }
    }
}
