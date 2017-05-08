using System.Collections.Generic;
using CmsCore.Library.Entities;

namespace CmsCore.Libary.Data.MySqlDao.Interfaces
{
    public interface IEntityDao
    {
        void CreateEntitiesTable();
        void CreateEntityTable(string tableName, List<AttributeModel> attributeModels);
    }
}