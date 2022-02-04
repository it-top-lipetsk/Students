namespace Students.DB_Lib
{
    public class ConnectionString
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }

        public override string ToString()
        {
            return $"Server={Server};Database={Database};Uid={Uid};Pwd={Pwd};";
        }
    }
}