using System;
using System.Threading;

namespace BastCricketer.Models
{
    public class CricketerProfile
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int ODI
        {
            get;
            set;
        }
        public int Tests
        {
            get;
            set;
        }
        public int OdiRuns
        {
            get;
            set;
        }
        public int TestRuns
        {
            get;
            set;
        }
        public int Type
        {
            get;
            set;
        }
    }

    public class Result
    {
        public int Status
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
    }
}