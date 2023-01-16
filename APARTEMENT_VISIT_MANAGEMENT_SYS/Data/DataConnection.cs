namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Data
{
    public class DataConnection
    {
        private string SqlString= String.Empty;
        public  DataConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            SqlString = builder.GetSection("ConnectionStrings:SqlString").Value;
        }

        public string GetString()
        {
            return SqlString;
        }
    }
}
