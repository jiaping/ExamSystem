using System.Collections.Generic;
using System.ServiceModel;
using JP.ExamSystem.ExamCommons.SetQuestion;

namespace JP.ExamSystem.SetQuestion
{
    public static class ServiceHelper
    {
        public static List<string> GetTqList(string filter)
        {
             using (
                ChannelFactory<ISetQuestionService> factory =
                    new ChannelFactory<ISetQuestionService>("ISetQuestionService"))
            {
                ISetQuestionService proxy = factory.CreateChannel();

                return proxy.GetTqList("111%");
            }
        }
    }
}
