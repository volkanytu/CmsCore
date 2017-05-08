using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace CmsCore.Libary.Data.MySqlDao
{
    public static class Extensions
    {
        public static MySqlParameter[] ToMySqlParameterList(this Dictionary<string, object> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var sqlParameters = new List<MySqlParameter>();
            if (dictionary.Count > 0)
            {
                sqlParameters.AddRange(from dictionaryKey in dictionary.Keys
                    let value = dictionary[dictionaryKey]
                    select new MySqlParameter
                    {
                        ParameterName = dictionaryKey,
                        Value = value != null ? dictionary[dictionaryKey] : DBNull.Value
                    });
            }

            return sqlParameters.ToArray();
        }
    }
}