using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppS7
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
