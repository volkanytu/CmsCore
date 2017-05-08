using System;

namespace CmsCore.Library.Entities
{
    public class CmsEntity
    {
        private int _id;

        private AttributeCollection _attributes;

        public CmsEntity(string entityName)
        {
            LogicalName = entityName;
        }

        public CmsEntity(string entityName, int id)
        {
            LogicalName = entityName;
            _id = id;
        }


        public AttributeCollection Attributes
        {
            get => _attributes ?? (_attributes = new AttributeCollection());
            set => _attributes = value;
        }

        public object this[string attributeName]
        {
            get => Attributes[attributeName];
            set => Attributes[attributeName] = value;
        }

        public virtual int Id
        {
            get => _id;
            set => _id = value;
        }
        public string LogicalName { get; set; }

        public bool Contains(string attributeName)
        {
            return Attributes.Contains(attributeName);
        }

        public virtual T GetAttributeValue<T>(string attributeLogicalName)
        {
            var attributeValue = GetAttributeValue(attributeLogicalName);
            if (attributeValue != null)
            {
                return (T) attributeValue;
            }
            return default(T);
        }

        private object GetAttributeValue(string attributeLogicalName)
        {
            if (string.IsNullOrWhiteSpace(attributeLogicalName))
            {
                throw new ArgumentNullException(nameof(attributeLogicalName));
            }

            return !Contains(attributeLogicalName) ? null : this[attributeLogicalName];
        }

        protected virtual void SetAttributeValue(string attributeLogicalName, object value)
        {
            if (string.IsNullOrWhiteSpace(attributeLogicalName))
            {
                throw new ArgumentNullException(nameof(attributeLogicalName));
            }

            this[attributeLogicalName] = value;
        }

        public CmsEntityReference ToEntityReference()
        {
            return new CmsEntityReference(LogicalName, Id);
        }
    }
}