using System.IO;
using static System.Text.Json.JsonSerializer;

namespace Students.DB_Lib
{
    public class DbConfig
    {
        private ConnectionString _str;
        private string _path;

        public DbConfig()
        {
            _path = "db_config.json";
            _str = new ConnectionString();
        }
        public DbConfig(string path)
        {
            _path = path;
            _str = new ConnectionString();
        }

        public string GetConnectionString()
        {
            using var file = new FileStream(_path, FileMode.Open);
            _str = DeserializeAsync<ConnectionString>(file).Result;
            return _str?.ToString();
        }
    }
}