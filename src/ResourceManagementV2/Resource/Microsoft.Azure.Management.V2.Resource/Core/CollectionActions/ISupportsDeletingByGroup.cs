using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    interface ISupportsDeletingByGroup
    {
        Task Delete(string resourceGroupName, string name);
    }
}
