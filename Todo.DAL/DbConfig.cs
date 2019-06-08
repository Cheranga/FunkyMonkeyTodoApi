using System;

namespace Todo.DAL
{
    public class DatabaseConfigFactory
    {
        public static DbConfig GetConfig()
        {
            return new DbConfig
            {
                ConnectionString = Environment.GetEnvironmentVariable("DatabaseConnection")
            };
        }
    }

    public class DbConfig
    {
        public string ConnectionString { get; set; }
    }
}