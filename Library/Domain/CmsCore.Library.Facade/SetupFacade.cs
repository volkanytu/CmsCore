using System;
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
            var tableList = new Dictionary<string, List<AttributeModel>>
            {
                {"cms_department", GetDepartmentTableAttributes().ToList()},
                {"cms_user", GetUserTableAttributes().ToList()},
                {"cms_entity", GetEntityTableAttributes().ToList()},
                {"cms_attribute", GetAttributeTableAttributes().ToList()},
                {"cms_stringmap", GetStringMapTableAttributes().ToList()},
                {"cms_statusmap", GetStatusMapTableAttributes().ToList()},
                {"cms_relation", GetRelationTableAttributes().ToList()}
            };

            foreach (var table in tableList)
            {
                _entityBusiness.CreateEntityTable(table.Key, table.Value);

                Console.WriteLine("{0} table created!", table.Key);
            }
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
                    Name = "cms_name",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "cms_title",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "cms_pluraltitle",
                    Length = 100
                },

                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "cms_description",
                    Length = 200
                },
                new AttributeModel
                {
                    DbType = DbType.BIT,
                    IsAutoIncrement = false,
                    IsNullable = false,
                    IsPk = false,
                    Name = "cms_iscustomizable",
                    DefaultValue = "1"
                },
            };
        }

        private static IEnumerable<AttributeModel> GetDepartmentTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_name",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_description",
                    IsNullable = true,
                    Length = 200
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_emailaddress",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_website",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_parentid",
                    IsNullable = true,
                },
                new AttributeModel
                {
                    DbType = DbType.DATETIME,
                    Name = "cms_createdon",
                    DefaultValue = "NOW()"
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_createdby",
                },
                new AttributeModel
                {
                    DbType = DbType.DATETIME,
                    Name = "cms_modifiedon",
                    DefaultValue = "NOW()"
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_modifiedby",
                },
            };
        }

        private static IEnumerable<AttributeModel> GetAttributeTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_name",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_title",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_entityid",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_crmtype",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_dbtype",
                },
                new AttributeModel
                {
                    DbType = DbType.BIT,
                    Name = "cms_isnullable",
                    DefaultValue = "0"
                },
                new AttributeModel
                {
                    DbType = DbType.BIT,
                    Name = "cms_ispk",
                    DefaultValue = "0"
                },
                new AttributeModel
                {
                    DbType = DbType.BIT,
                    Name = "cms_isautoincrement",
                    DefaultValue = "0"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_defaultvalue",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_length",
                    IsNullable = true
                },
            };
        }

        private static IEnumerable<AttributeModel> GetUserTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_name",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_username",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_password",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_firstname",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_lastname",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_departmentid",
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_title",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_emailaddress",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_website",
                    IsNullable = true,
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.DATETIME,
                    Name = "cms_createdon",
                    DefaultValue = "NOW()"
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_createdby",
                },
                new AttributeModel
                {
                    DbType = DbType.DATETIME,
                    Name = "cms_modifiedon",
                    DefaultValue = "NOW()"
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_modifiedby",
                },
            };
        }

        private static IEnumerable<AttributeModel> GetStringMapTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_attributename",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_value",
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_text",
                    Length = 100
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_entityid",
                },
            };
        }

        private static IEnumerable<AttributeModel> GetStatusMapTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_state",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_status",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_entityid",
                },
            };
        }

        private static IEnumerable<AttributeModel> GetRelationTableAttributes()
        {
            return new List<AttributeModel>()
            {
                new AttributeModel
                {
                    DbType = DbType.INT,
                    EntityModelId = 1,
                    IsAutoIncrement = true,
                    IsPk = true,
                    Name = "id"
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_name",
                    Length = 200
                },
                new AttributeModel
                {
                    DbType = DbType.VARCHAR,
                    Name = "cms_tablename",
                    IsNullable = true,
                    Length = 200
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_referencingentityid",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_referencingattributeid",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_referencedentityid",
                },
                new AttributeModel
                {
                    DbType = DbType.INT,
                    Name = "cms_referencedattributeid",
                },
            };
        }
    }
}