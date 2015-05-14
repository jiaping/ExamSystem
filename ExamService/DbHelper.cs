using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.ExamSystem.ExamService
{
    public static class DbHelper
    {
#if DEBUG
        private static string connString = @"Data Source=D:\develop\ExamSystem\db\ExamDB.sdf";
#else
        private static string connString = @"Data Source=|DataDirectory|ExamDB.sdf";
#endif

        public static List<string> GetTqList(string filter)
        {
            List<string> tqList=new List<string>();
            using (SqlCeConnection conn = new SqlCeConnection(connString))
            {
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Id] FROM TestQuestions where Id like '"+filter+"'";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tqList.Add(reader.GetString(0));
                }
            }
            return tqList;
        }
    }
}
