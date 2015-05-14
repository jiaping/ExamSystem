using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JP.ExamSystem.ExamCommons
{
    /// <summary>
    /// 用于wcf中表示心跳数据
    /// </summary>
    [DataContract]
    public struct HeartInfo
    {
        [DataMember]
        public string ID;
        [DataMember]
        public int RemainTime;
        [DataMember]
        public ExamStatus ExamStatus;
    }
   
}
