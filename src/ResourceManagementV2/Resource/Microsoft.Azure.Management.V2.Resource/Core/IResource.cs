using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public interface IResource
    {
        string Id { get; }
        string Type { get; }
        string Name { get; }
        string RegionName { get; }

        // TODO Region Region { get; }
        IReadOnlyDictionary<string, string> Tags { get; }
    }
}
