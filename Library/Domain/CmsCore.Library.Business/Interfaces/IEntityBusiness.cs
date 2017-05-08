using System.Collections.Generic;
using CmsCore.Library.Entities;

namespace CmsCore.Library.Business.Interfaces
{
    public interface IEntityBusiness
    {
        void CreateEntityTable(string tableName, List<AttributeModel> attributeModels);
    }
}