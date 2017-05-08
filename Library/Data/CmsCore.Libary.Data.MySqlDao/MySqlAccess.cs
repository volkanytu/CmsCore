using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using CmsCore.Library.Data.Interfaces;
using CmsCore.Library.Entities;
using MySql.Data.MySqlClient;

namespace CmsCore.Libary.Data.MySqlDao
{
    public class MySqlAccess : IDbAccess
    {
        private readonly string _connectionString;
        private const int SqlCommandTimeOut = 60 * 3600;

        public MySqlAccess(string connectionString,string dbName)
        {
            _connectionString = connectionString;
            DbName = dbName;
        }

        public string DbName { get; }

        public ResultTable GetDataTable(string query, Dictionary<string, object> parameters = null)
        {
            return GetDataTable(query, CommandType.Text, parameters.ToMySqlParameterList());
        }

        public ResultTable GetDataTableSp(string spName, Dictionary<string, object> parameters = null)
        {
            return GetDataTable(spName, CommandType.StoredProcedure, parameters.ToMySqlParameterList());
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            return ExecuteNonQuery(query, CommandType.Text, parameters.ToMySqlParameterList());
        }

        public int ExecuteNonQuerySp(string query, Dictionary<string, object> parameters = null)
        {
            return ExecuteNonQuery(query, CommandType.StoredProcedure, parameters.ToMySqlParameterList());
        }

        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            return ExecuteScalar(query, CommandType.Text, parameters.ToMySqlParameterList());
        }

        public object ExecuteScalarSp(string query, Dictionary<string, object> parameters = null)
        {
            return ExecuteScalar(query, CommandType.StoredProcedure, parameters.ToMySqlParameterList());
        }

        #region | PRIVATE METHODS |

        private object ExecuteScalar(string query, CommandType commandType, params MySqlParameter[] parameters)
        {
            object result = null;

            using (var sqlConn = new MySqlConnection(_connectionString))
            {
                sqlConn.Open();

                using (var sqlCmd = new MySqlCommand(query, sqlConn))
                {
                    sqlCmd.CommandTimeout = SqlCommandTimeOut;
                    sqlCmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        sqlCmd.Parameters.AddRange(parameters);
                    }

                    result = sqlCmd.ExecuteScalar();
                }
            }

            return result;
        }

        private int ExecuteNonQuery(string query, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (var sqlConn = new MySqlConnection(_connectionString))
            {
                sqlConn.Open();

                using (var sqlCmd = new MySqlCommand(query, sqlConn))
                {
                    sqlCmd.CommandTimeout = SqlCommandTimeOut;
                    sqlCmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        sqlCmd.Parameters.AddRange(parameters);
                    }

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }

        private ResultTable GetDataTable(string text, CommandType commandType, params MySqlParameter[] parameters)
        {
            ResultTable resultSet;

            using (var sqlConn = new MySqlConnection(_connectionString))
            {
                sqlConn.Open();

                using (var sqlCmd = new MySqlCommand(text, sqlConn))
                {
                    sqlCmd.CommandTimeout = SqlCommandTimeOut;
                    sqlCmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        sqlCmd.Parameters.AddRange(parameters);
                    }

                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        resultSet = FillDataTable(reader);
                    }
                }
            }

            return resultSet;
        }

        private ResultTable FillDataTable(DbDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            var defined = false;
            var table = new ResultTable();
            var index = 0;

            while (reader.Read())
            {
                var values = new object[reader.FieldCount];

                if (!defined)
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var column = new ResultColumn()
                        {
                            ColumnName = reader.GetName(i),
                            ColumnType = reader.GetFieldType(i)
                        };
                        table.Columns.Add(column);
                    }
                    defined = true;
                }

                reader.GetValues(values);

                table.Rows.Add(new ResultRow(table.Columns, values));

                index++;
            }

            table.TotalCount = index;

            return table;
        }

        #endregion
    }
}