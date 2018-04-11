using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.ViewModels
{
    public class AttributeListViewModel
    {
        public IEnumerable<Models.Attribute> Attributes { get; set; }

        public bool ShowDefinitionName { get; set; }

        public bool ShowCommandLinks { get; set; }

    }
}