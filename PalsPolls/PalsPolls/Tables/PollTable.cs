using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;
using Syncfusion;

namespace PalsPolls.Tables
{

    public class PollTable
    {
        public PollTable() { }
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public Guid PostId { get; set; }
        public String PostUserName { get; set; }
        public String PostContent { get; set; }
    }

}

