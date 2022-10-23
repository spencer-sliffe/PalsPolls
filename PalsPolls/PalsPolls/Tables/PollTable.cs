using System;
using SQLite;

namespace PalsPolls.Tables
{
    public class PollTable
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public Guid PostId { get; set; }
        public String PostUserName { get; set; }
        public String PostContent { get; set; }
        public int RightNum { get; set; }
        public int LeftNum { get; set; }
    }
}

