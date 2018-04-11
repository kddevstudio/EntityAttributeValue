using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.ViewModels
{
    public class EntityDefinitionViewModel
    {
        public int EntityDefinitionId { get; set; }

        public string Name { get; set; }

        public virtual IList<Models.Attribute> Attributes { get; set; }

        public virtual IList<EntityDefinition> EntityDefinitionParents { get; set; }

        public virtual IList<EntityDefinition> EntityDefinitionChildren { get; set; }

        public AttributeListViewModel AttributeList { get; set; }
    }
}