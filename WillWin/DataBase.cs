using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WillWin.Models;

namespace WillWin
{
    public class DataBase
    {

        private readonly SQLiteConnection conn;

        public DataBase(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<LoginViewModel>();
        }

        public List<LoginViewModel> GetItems()
        {
            return conn.Table<LoginViewModel>().ToList();
        }

        public int SaveItem(LoginViewModel item)
        {
            return conn.Insert(item);
        }

    }
}
