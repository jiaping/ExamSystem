using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JP.ExamSystem.ExamCommons.SetQuestion
{
    [ServiceContract]
    public interface ISetQuestionService
    {
        /// <summary>
        /// 获取试题列表
        /// </summary>
        /// <param name="filter">根据题型选择的过滤</param>
        /// <returns></returns>
        [OperationContract]
        List<string> GetTqList(string filter);
         string AddOrUpadte();
    }
}
