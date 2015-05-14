using System;
using System.ServiceModel;
using JP.ExamSystem.ExamCommons;
using JP.ExamSystem.ExamCommons.Services;

namespace JP.ExamSystem.ExamService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“TesterInfoManagerService”。
    public class TesterInfoManagerService : ITesterInfoManagerService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region ITesterInfoManagerService 成员


        public void SendTesterInfo(TesterInfo ti)
        {
            string clientIP=ClientIPHelper.Instance().ClientIp();
            TesterInfoManager.AddorUpdate(ti);
        }

        #endregion
    }
}
