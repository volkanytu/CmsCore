namespace CmsCore.Library.Entities
{
    public class LogItem
    {
        public LogItem(string logKey)
        {
            LogKey = logKey;
        }

        public string LogKey { get; }
        public string ErrorMessage { get; set; }
        public string RecordId { get; set; }
    }
}