using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.ExamSystem.ExamCommons.SetQuestion
{
    public class TestQuestion
    {
        public string Id { get; set; }
        public byte[] Content { get; set; }
        public byte[] Requirement { get; set; }
        public byte[] ModelAnswer { get; set; }
        public byte[] Comment { get; set; } 
    }
}
