using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    interface IResource
    {
        string Id { get; }
        string Type { get; }
        string Name { get; }
        string RegionName { get; }

        // TODO Region Region { get; }
        IReadOnlyDictionary<string, string> Tags { get; }
    }
}
