using System;
using Autofac;
using CmsCore.Library.Data.Interfaces;
using CmsCore.Library.Entities;
using CmsCore.Library.Facade.Interfaces;

namespace CmsCore.ConsoleApp.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = IocContainerConfig.GetContainer();

            Console.WriteLine("cms_entity Table update test11_{0}", DateTime.Now);

            var entityAccess = container.Resolve<IEntityAccess>();

            var entity = new CmsEntity("cms_entity", 4)
            {
                ["name"] = "cms_account",
                ["title"] = "Firma",
                ["pluraltitle"] = "Firmalar",
                ["description"] = "Firma Data Container"
            };

            //var insertedId =entityAccess.Create(entity);
            entityAccess.Update(entity);
            //entityAccess.Delete("cms_entity", 3);

            //Console.WriteLine("Inserted Entity Id:{0}", insertedId.ToString());
            Console.WriteLine("updated Entity Id:{0}", entity.Id);

//            Console.WriteLine("Setup Tables Started_{0}kl",DateTime.Now);

//            var setupFacade = container.Resolve<ISetupFacade>();
//            setupFacade.SetupTables();

//            var mySqlAccess = container.Resolve<IDbAccess>();

//            var parameters = new Dictionary<string, object> {{"@Id", 2}};

//            var dt = mySqlAccess.GetDataTable("SELECT * FROM tblTest WHERE Id=@Id", parameters);
//            //var dt = mySqlAccess.GetDataTable("SELECT * FROM tblTest");
//
//            foreach (var row in dt.Rows)
//            {
//                Console.WriteLine("{0}|{1}", row["Id"].ToString(), row["Name"].ToString());
//            }
//
//
//            Console.WriteLine("Create Table Start");
//
//            var entityDao = container.Resolve<IEntityDao>();
//
//            entityDao.CreateEntitiesTable();
//
//            Console.WriteLine("Entity table created");

//            var entityDao = container.Resolve<IEntityDao>();

//            List<AttributeModel> attributeModels = new EditableList<AttributeModel>()
//            {
//                new AttributeModel
//                {
//                    Id = 1,
//                    CrmType = CrmType.INT,
//                    DbType = DbType.INT,
//                    EntityModelId = 1,
//                    IsAutoIncrement = true,
//                    IsNullable = false,
//                    IsPk = true,
//                    Name = "Id"
//                },
//                new AttributeModel
//                {
//                    Id = 2,
//                    CrmType = CrmType.STRING,
//                    DbType = DbType.VARCHAR,
//                    EntityModelId = 1,
//                    IsAutoIncrement = false,
//                    IsNullable = false,
//                    IsPk = false,
//                    Name = "cms_name",
//                    Length = 50
//                },
//                new AttributeModel
//                {
//                    Id = 3,
//                    CrmType = CrmType.DATETIME,
//                    DbType = DbType.DATETIME,
//                    EntityModelId = 1,
//                    IsAutoIncrement = false,
//                    IsNullable = false,
//                    IsPk = false,
//                    Name = "cms_createdon",
//                    DefaultValue = "NOW()"
//
//                },
//                new AttributeModel
//                {
//                    Id = 4,
//                    CrmType = CrmType.BOOL,
//                    DbType = DbType.BIT,
//                    EntityModelId = 1,
//                    IsAutoIncrement = false,
//                    IsNullable = false,
//                    IsPk = false,
//                    Name = "cms_ismalta",
//                    DefaultValue = "0"
//                },
//            };
//
//            var entityModel = new EntityModel
//            {
//                Id = 1,
//                Description = "Firma Kaydı",
//                IsCustomizable = true,
//                Name = "cms_account",
//                PluralTitle = "Firmalar",
//                Title = "Firma",
//                AttributeModels = attributeModels
//            };

//            entityDao.CreateEntityTable(entityModel);
        }
    }
}