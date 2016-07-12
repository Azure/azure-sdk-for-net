using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Definition
{
    public interface IDefinition<T> : IWithTags<T>
    {
    }

    public interface IWithRegion<T>
    {
        T withRegion(string regionName);
    }

    public interface IWithTags<T>
    {
        T withTags(IDictionary<string, string> tags);

        T withTag(string key, string value);
    }
}
