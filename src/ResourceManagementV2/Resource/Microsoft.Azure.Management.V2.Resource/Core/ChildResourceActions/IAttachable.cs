using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ChildModel
{
    interface IAttachable<ParentT>
    {
        ParentT Attach();
    }
}
