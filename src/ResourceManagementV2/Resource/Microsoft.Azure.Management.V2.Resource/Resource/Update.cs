using System.Collections.Generic;

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
