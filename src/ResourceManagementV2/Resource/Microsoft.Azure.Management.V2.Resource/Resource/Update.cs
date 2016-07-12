using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Update
{
    public interface IUpdate<T> : IWithTags<T>
    {
    }

    public interface IWithTags<T>
    {
        T WithTags(IDictionary<string, string> tags);

        T WithTag(string key, string value);

        T withoutTag(string key);
    }
}
