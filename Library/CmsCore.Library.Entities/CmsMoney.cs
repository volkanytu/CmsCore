namespace CmsCore.Library.Entities
{
    public class CmsMoney
    {
        public decimal Value { get; set; }

        public CmsMoney()
        {
        }

        public CmsMoney(decimal value)
        {
            Value = value;
        }
    }
}