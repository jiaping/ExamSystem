using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using JP.ExamSystem.ExamCommons;
using JP.ExamSystem.ExamCommons.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jp.ExamSystem.ExamServiceTest
{
    [TestClass]
    public class TesterInfoManagerTest
    {
        [TestMethod]
        [TestCategory("测试SendTesterInfo")]
        public void SendTesterInfoTest()
        {
            using (
                ChannelFactory<ITesterInfoManagerService> factory =
                    new ChannelFactory<ITesterInfoManagerService>("ITesterInfoManagerService"))
            {
                ITesterInfoManagerService proxy = factory.CreateChannel();
                TesterInfo ti = new TesterInfo()
                {
                    Id = "11111100103",
                    Name = "jiaping3",
                    Port = 21,
                    RemainTime = 900,
                    Status = ExamStatus.EsExamining,
                    Ip = "192.168.0.1"
                };
                proxy.SendTesterInfo(ti);
                ti.Id = "11111100102";
                ti.Name = "jiaping2";
                proxy.SendTesterInfo(ti);
                
            }
        }
    }
}
