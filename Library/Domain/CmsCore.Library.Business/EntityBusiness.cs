using System;
using System.Collections.Generic;
using CmsCore.Libary.Data.MySqlDao.Interfaces;
using CmsCore.Library.Business.Interfaces;
using CmsCore.Library.Entities;

namespace CmsCore.Library.Business
{
    public class EntityBusiness : IEntityBusiness
    {
        private readonly IEntityDao _entityDao;

        public EntityBusiness(IEntityDao entityDao)
        {
            _entityDao = entityDao;
        }

        public void CreateEntityTable(string tableName, List<AttributeModel> attributeModels)
        {
            _entityDao.CreateEntityTable(tableName, attributeModels);
        }
    }
}