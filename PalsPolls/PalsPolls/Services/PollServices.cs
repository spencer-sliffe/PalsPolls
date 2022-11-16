using System;
using PalsPolls.Tables;
using SQLite;
using PalsPolls.Views;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using Xamarin.Essentials;

namespace PalsPolls.Services
{
    public class PollServices
    { 
        private readonly SQLiteAsyncConnection db1;

        public PollServices(string dbPath)
        {           
            db1 = new SQLiteAsyncConnection(dbPath);
            db1.CreateTableAsync<PollTable>();
        }

        public async Task CreatePoll(PollTable m_poll)
        {
            await db1.InsertAsync(m_poll);
        }

        public async Task<IEnumerable<PollTable>> ReadPosts()
        {
            return await db1.Table<PollTable>().ToListAsync();
        }

        public Task DeletePost(PollTable m_Table)
        {
            return db1.DeleteAsync(m_Table);
        }

        public async Task<ObservableCollection<PollTable>> Init()
        {
            await db1.CreateTableAsync<PollTable>();
            var polls = await db1.Table<PollTable>().ToListAsync();
            var PollsCollection = new ObservableCollection<PollTable>(polls);
            return PollsCollection;
        }
    }
}

