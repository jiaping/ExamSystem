using JP.ExamSystem.ExamCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JP.ExamSystem.ExamCommons
{
    /// <summary>
    /// 表示客户机考生考试状态
    /// </summary>
    public class TesterInfo
    {
        /// <summary>
        /// 考生号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 考生姓名
        /// </summary>
        public string Name { get; set; }             
        /// <summary>
        /// 客户机IP
        /// </summary>
        public string Ip { get; set; }   
        /// <summary>
        /// 客户机端口
        /// </summary>
        public int Port;
        /// <summary>
        /// 客户机状态
        /// </summary>
        public ExamStatus Status { get; set; }   
        /// <summary>
        /// 考试剩余时间
        /// </summary>
        public int RemainTime { get; set; }   
    }

    /// <summary>
    /// 枚举考试状态
    /// </summary>
    [DataContract]
    public enum ExamStatus
    {
        [EnumMember]
        EsLogin,                //登录
        [EnumMember]
        EsExamining         //考试中
    }
}
