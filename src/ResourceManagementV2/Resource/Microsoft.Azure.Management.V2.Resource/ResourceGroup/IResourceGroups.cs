using Microsoft.Azure.Management.V2.Resource.Core.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup
{
    public interface IResourceGroups :
        ISupportsCreating<Definition.IBlank>
    {
    }
}
