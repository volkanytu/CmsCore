using System.Collections.Generic;

namespace CmsCore.Library.Constants.SqlQueries
{
    public abstract class BaseQuery
    {
        protected BaseQuery()
        {
            ParameterDict = new Dictionary<string, object>();
        }

        public Dictionary<string, object> ParameterDict { get; set; }

        public abstract string SqlQuery { get; }
    }
}