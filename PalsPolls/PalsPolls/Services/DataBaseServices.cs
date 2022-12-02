using System;
using PalsPolls.Tables;
using SQLite;
using PalsPolls.Views;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace PalsPolls.Services
{
    public class DataBaseServices
    {
        private readonly SQLiteAsyncConnection db;

        public DataBaseServices(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<RegUserTable>();            
        }

        public String HashPass(String password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }


        public Task CreateLogin(RegUserTable regUser)
        {
            return db.InsertAsync(regUser);
        }

        public Task<List<RegUserTable>> ReadUsers()
        {
            return db.Table<RegUserTable>().ToListAsync();
        }

        public Task UpdateUser(RegUserTable regUser)
        {
            return db.UpdateAsync(regUser);
        }

        public Task DeleteUser(RegUserTable regUser)
        {
            return db.DeleteAsync(regUser);
        }
    }
}

