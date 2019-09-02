namespace Pazzo.Exam.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pazzo.Exam;
    using Pazzo.Exam.ViewModel;
    using Pazzo.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass()]
    public class SoldierExamServiceTests
    {
        [TestMethod()]
        public void SortExamResultTest()
        {
            this.InitUserInfo();
            UserService userService = new UserService();
            var users = userService.GetUsers();
            List<ExamResult> examResults = new List<ExamResult>();
            examResults.Add(new ExamResult()
            {
                ChineseResult = 50,
                EnglishResult = 50,
                MathResult = 50,
                User = users.Where(c => c.Name.Equals("TH.Lee1")).FirstOrDefault()
            });
            examResults.Add(new ExamResult()
            {
                ChineseResult = 60,
                EnglishResult = 60,
                MathResult = 60,
                User = users.Where(c => c.Name.Equals("TH.Lee2")).FirstOrDefault()
            });
            examResults.Add(new ExamResult()
            {
                ChineseResult = 70,
                EnglishResult = 70,
                MathResult = 70,
                User = users.Where(c => c.Name.Equals("TH.Lee3")).FirstOrDefault()
            });
            var examService = ExamFactory.GetService(ExamCatalog.SoldierExam);
            var sortUsers = examService.SortExamResult(examResults);
            Assert.IsTrue(sortUsers.FirstOrDefault().Name.Equals("TH.Lee3"));
            var changeResult = examResults.Where(c => c.User.Name.Equals("TH.Lee2")).FirstOrDefault();
            changeResult.ChineseResult = 80;
            changeResult.EnglishResult = 80;
            changeResult.MathResult = 80;
            sortUsers = examService.SortExamResult(examResults);
            Assert.IsTrue(sortUsers.FirstOrDefault().Name.Equals("TH.Lee2"));
        }

        private void InitUserInfo()
        {
            UserService userService = new UserService();
            Assert.IsTrue(userService.DeleteUsers());
            DB.User user = new DB.User();
            user.Id = Guid.NewGuid();
            user.Name = "TH.Lee1";
            Assert.IsTrue(userService.CreateUser(user));
            user.Id = Guid.NewGuid();
            user.Name = "TH.Lee2";
            Assert.IsTrue(userService.CreateUser(user));
            user.Id = Guid.NewGuid();
            user.Name = "TH.Lee3";
            Assert.IsTrue(userService.CreateUser(user));
        }
    }
}