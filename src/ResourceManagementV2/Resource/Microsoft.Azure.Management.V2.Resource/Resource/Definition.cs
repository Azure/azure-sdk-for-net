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
        T WithRegion(string regionName);
    }

    public interface IWithTags<T>
    {
        T WithTags(IDictionary<string, string> tags);

        T WithTag(string key, string value);
    }
}
