using CmsCore.Library.Entities;

namespace CmsCore.Library.Data.Interfaces
{
    public interface IEntityAccess
    {
        object Create(CmsEntity entity);
        void Delete(string entityName, int id);
        void Update(CmsEntity entity);
    }
}