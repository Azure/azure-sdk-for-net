using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Definition;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup
{
    public class ResourceGroups : 
        IResourceGroups
    {
        public IBlank Define(string name)
        {
            return new ResourceGroup(null, null);
        }
    }
}
