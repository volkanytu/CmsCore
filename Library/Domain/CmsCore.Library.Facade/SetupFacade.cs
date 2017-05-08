using System.Collections.Generic;
using System.Linq;
using CmsCore.Library.Business.Interfaces;
using CmsCore.Library.Entities;
using CmsCore.Library.Entities.Enums;
using CmsCore.Library.Facade.Interfaces;

namespace CmsCore.Library.Facade
{
    public class SetupFacade : ISetupFacade
    {
        private readonly IEntityBusiness _entityBusiness;

        public SetupFacade(IEntityBusiness entityBusiness)
        {
            _entityBusiness = entityBusiness;
        }

        public void SetupTables()
        {
            var entityAttributes = GetEntityTableAttributes();

            _entityBusiness.CreateEntityTable("cms_entity", entityAttributes.ToList());
        }

        private static IEnumerable<AttributeModel> GetEntityTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsNullable = false,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "name",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "title",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "pluraltitle",
                    Length = 100
                },

                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "description",
                    Length = 200
                },
                new AttributeModel
                {
                    DbType = DbType.BIT,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "iscustomizable",
                    DefaultValue = "1"
                },
            };
        }
    }
}