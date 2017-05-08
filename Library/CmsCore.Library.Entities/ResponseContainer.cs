namespace CmsCore.Library.Entities
{
    public class ResponseContainer<T>
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}