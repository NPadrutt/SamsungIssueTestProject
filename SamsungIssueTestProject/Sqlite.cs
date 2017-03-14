using System;
using System.IO;
using FriendsAppDate.Foundation.Interfaces;

namespace SamsungIssueTestProject
{
    public class Sqlite : ISqlite
    {
        public string DbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbName.db");
    }
}