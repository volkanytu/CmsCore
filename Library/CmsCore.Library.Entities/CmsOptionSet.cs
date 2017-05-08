namespace CmsCore.Library.Entities
{
    public class CmsOptionSet
    {
        public int Value { get; set; }
        public string Description { get; set; }

        public CmsOptionSet()
        {
        }

        public CmsOptionSet(int value)
        {
            Value = value;
        }

        public CmsOptionSet(int value,string description)
        {
            Value = value;
            Description = description;
        }
    }
}