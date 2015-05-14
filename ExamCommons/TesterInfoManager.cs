using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace JP.ExamSystem.ExamCommons
{
    public static class TesterInfoManager
    {
        private static readonly ConcurrentDictionary<string, TesterInfo> testerInfoDict;

        static TesterInfoManager()
        {
            testerInfoDict = new ConcurrentDictionary<string, TesterInfo>();
        }

        public static void AddorUpdate(TesterInfo ti)
        {
            testerInfoDict.AddOrUpdate(ti.Id, ti, (key, oldValue) =>
            {
                oldValue.Status = ti.Status;
                oldValue.RemainTime = ti.RemainTime;
                return oldValue;
            });
            TesterInfosChanged(null,new TesterInfosChangedEventArgs(ti));
        }

        public static TesterInfo GetDict(string key)
        {
            TesterInfo ti;
            testerInfoDict.TryGetValue(key, out ti);
            return ti;
        }

        public static List<TesterInfo> GetList()
        {
            return testerInfoDict.Values.ToList();
        }

        public static event EventHandler<TesterInfosChangedEventArgs> TesterInfosChanged;
    }

    public class TesterInfosChangedEventArgs : EventArgs
    {
        public TesterInfo ChangedItem;
        public TesterInfosChangedEventArgs(TesterInfo ti)
        {
            ChangedItem = ti;
        }
    }
  
}
