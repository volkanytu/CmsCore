using System.Collections.Generic;

namespace CmsCore.Libary.Data.MySqlDao
{
    public class SqlQuery
    {
        public string Query { get; set; }
        public Dictionary<string, object> parameters { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}