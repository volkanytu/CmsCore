using System;
using System.Collections.Generic;
using System.Linq;
using CmsCore.Library.Data.Interfaces;
using CmsCore.Library.Entities;

namespace CmsCore.Libary.Data.MySqlDao
{
    public class MySqlEntityDao : IEntityAccess
    {
        private readonly IDbAccess _dbAccess;

        public MySqlEntityDao(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }


        public object Create(CmsEntity entity)
        {
            var query = GetInsertQuery(entity);

            Console.WriteLine(query.Query);

            return _dbAccess.ExecuteScalar(query.Query, query.parameters);
        }

        public void Delete(string entityName, int id)
        {
            var query = GetDeleteQuery(entityName, id);

            _dbAccess.ExecuteNonQuery(query.Query, query.parameters);
        }

        public void Update(CmsEntity entity)
        {
            var query = GetUpdateQuery(entity);

            _dbAccess.ExecuteNonQuery(query.Query, query.parameters);
        }


        #region | PRIVATE METHODS |

        protected virtual SqlQuery GetInsertQuery(CmsEntity entity)
        {
            var columnNames = string.Join(",", entity.Attributes.Keys);

            var sqlParameters = "@" + string.Join(",@", entity.Attributes.Keys);

            var lstParameters = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> item in entity.Attributes)
            {
                FillSqlParameter(item, lstParameters);
            }

            var sqlQuery = string.Format("INSERT INTO {0} ({1}) VALUES ({2}); SELECT LAST_INSERT_ID()",
                entity.LogicalName,
                columnNames, sqlParameters);

            return new SqlQuery()
            {
                Query = sqlQuery,
                parameters = lstParameters
            };
        }

        protected virtual SqlQuery GetUpdateQuery(CmsEntity entity)
        {
            var lstSetQuery = new List<string>();
            var lstParameters = new Dictionary<string, object> {{"@Id", entity.Id}};


            foreach (KeyValuePair<string, object> item in entity.Attributes)
            {
                lstSetQuery.Add(string.Format("{0} = @{0} ", item.Key));

                FillSqlParameter(item, lstParameters);
            }

            var setQuery = string.Join(",", lstSetQuery);

            var sqlQuery = string.Format("UPDATE {0} SET {1} WHERE id=@Id", entity.LogicalName, setQuery);

            return new SqlQuery()
            {
                Query = sqlQuery,
                parameters = lstParameters
            };
        }

        protected virtual SqlQuery GetDeleteQuery(string entityName, int id)
        {
            var lstParameters = new Dictionary<string, object> {{"@id", id}};

            var sqlQuery = string.Format("DELETE FROM {0} WHERE id=@id", entityName);

            return new SqlQuery()
            {
                Query = sqlQuery,
                parameters = lstParameters
            };
        }

        protected virtual void FillSqlParameter(KeyValuePair<string, object> item,
            Dictionary<string, object> parameters)
        {
            var cmsEntityReference = item.Value as CmsEntityReference;
            if (cmsEntityReference != null)
            {
                parameters.Add("@" + item.Key, cmsEntityReference.Id);
            }
            else if (item.Value is CmsOptionSet)
            {
                parameters.Add("@" + item.Key, ((CmsOptionSet) item.Value).Value);
            }
            else if (item.Value is CmsMoney)
            {
                parameters.Add("@" + item.Key, ((CmsMoney) item.Value).Value);
            }
            else
            {
                parameters.Add("@" + item.Key, item.Value);
            }
        }

        #endregion
    }
}