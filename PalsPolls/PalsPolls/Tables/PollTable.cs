using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;
using Syncfusion;

namespace PalsPolls.Tables
{

    public class PollTable
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public Guid PostId { get; set; }
        public String PostUserName { get; set; }
        public String PostContent { get; set; }
        public String PostContent1 { get; set; }
        public String PostContent2 { get; set; }
        public DateTime CreatedDate { get; set; }

        public PollTable()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

}

