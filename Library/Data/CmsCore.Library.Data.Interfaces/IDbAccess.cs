using System.Collections.Generic;
using CmsCore.Library.Entities;

namespace CmsCore.Library.Data.Interfaces
{
    public interface IDbAccess
    {
        ResultTable GetDataTable(string query, Dictionary<string, object> parameters=null);
        ResultTable GetDataTableSp(string spName, Dictionary<string, object> parameters=null);
        int ExecuteNonQuery(string query, Dictionary<string, object> parameters=null);
        int ExecuteNonQuerySp(string query, Dictionary<string, object> parameters=null);
        object ExecuteScalar(string query, Dictionary<string, object> parameters=null);
        object ExecuteScalarSp(string query, Dictionary<string, object> parameters=null);
        string DbName { get; }
    }
}