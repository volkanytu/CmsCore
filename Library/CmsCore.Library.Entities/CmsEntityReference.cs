namespace CmsCore.Library.Entities
{
    public class CmsEntityReference
    {
        public CmsEntityReference()
        {
        }

        public CmsEntityReference(string logicalName)
        {
            LogicalName = logicalName;
        }

        public CmsEntityReference(string logicalName, int id)
        {
            LogicalName = logicalName;
            Id = id;
        }

        public int Id { get; set; }

        public string LogicalName { get; set; }

        public string Name { get; set; }
    }
}