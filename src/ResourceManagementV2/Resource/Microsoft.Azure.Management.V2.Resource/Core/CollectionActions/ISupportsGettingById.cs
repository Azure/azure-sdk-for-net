using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    interface ISupportsGettingById<T>
    {
        Task<T> GetById(string id);
    }
}
