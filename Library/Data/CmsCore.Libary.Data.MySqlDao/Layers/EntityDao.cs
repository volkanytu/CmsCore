using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmsCore.Libary.Data.MySqlDao.Interfaces;
using CmsCore.Library.Constants.SqlQueries;
using CmsCore.Library.Data.Interfaces;
using CmsCore.Library.Entities;
using CmsCore.Library.Entities.Enums;

namespace CmsCore.Libary.Data.MySqlDao.Layers
{
    public class EntityDao : IEntityDao
    {
        private readonly IDbAccess _dbAccess;

        public EntityDao(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public void CreateEntitiesTable()
        {
            var query = new CreateEntitiesTableQuery();

            _dbAccess.ExecuteNonQuery(query.SqlQuery);
        }

        public void CreateEntityTable(string tableName, List<AttributeModel> attributeModels)
        {
            var pkColumnName = attributeModels.First(c => c.IsPk).Name;

            var columnQueries = GetTableColumnsQueries(attributeModels);

            var query = new CreateEntityTableQuery(tableName, pkColumnName, columnQueries);

            Console.WriteLine(query.SqlQuery);

            _dbAccess.ExecuteNonQuery(query.SqlQuery);
        }

        private static string GetTableColumnsQueries(IEnumerable<AttributeModel> attributeModels)
        {
            var stringBuilder = new StringBuilder();

            foreach (var attributeModel in attributeModels)
            {
                var colName = attributeModel.Name;

                var dbType = attributeModel.DbType.ToString();
                if (attributeModel.DbType == DbType.VARCHAR)
                {
                    dbType = string.Format("{0}({1})", attributeModel.DbType.ToString(), attributeModel.Length);
                }

                var nullType = attributeModel.IsNullable ? " NULL " : " NOT NULL";
                var autoIncrement = attributeModel.IsAutoIncrement ? " AUTO_INCREMENT " : string.Empty;

                var defaultValue = string.Empty;

                if (!string.IsNullOrWhiteSpace(attributeModel.DefaultValue))
                {
                    defaultValue = string.Concat(" DEFAULT ", attributeModel.DefaultValue);
                }

                stringBuilder.AppendLine($" {colName} {dbType} {nullType} {autoIncrement} {defaultValue}, ");
            }

            return stringBuilder.ToString();
        }
    }
}