using System;
using System.Collections.Generic;

namespace CmsCore.Library.Entities
{
    public class EntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string PluralTitle { get; set; }
        public string Description { get; set; }
        public bool? IsCustomizable { get; set; }
        public List<AttributeModel> AttributeModels { get; set; }
    }
}