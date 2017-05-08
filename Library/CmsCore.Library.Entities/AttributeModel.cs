using CmsCore.Library.Entities.Enums;

namespace CmsCore.Library.Entities
{
    public class AttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EntityModelId { get; set; }
        public CrmType CrmType { get; set; }
        public DbType DbType { get; set; }
        public bool IsNullable { get; set; }
        public bool IsPk { get; set; }
        public bool IsAutoIncrement { get; set; }
        public string DefaultValue { get; set; }
        public int Length { get; set; }
    }
}