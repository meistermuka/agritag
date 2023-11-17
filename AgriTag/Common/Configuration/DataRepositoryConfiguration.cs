namespace AgriTag.Common.Configuration
{
    public class DataRepositoryConfiguration
    {
        public static string SectionName => nameof(DataRepositoryConfiguration);

        public string ConnectionString { get; set; }

        public DataRepositoryConfiguration()
        {
            ConnectionString = string.Empty;
        }
    }
}
