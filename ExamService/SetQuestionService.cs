using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.ExamSystem.ExamCommons.SetQuestion;

namespace JP.ExamSystem.ExamService
{
    public class SetQuestionService:ISetQuestionService
    {
        #region ISetQuestionService 成员

        public List<string> GetTqList(string filter)
        {
            return DbHelper.GetTqList("111%");
        }

        public string AddOrUpadte()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
