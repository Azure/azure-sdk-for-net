using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class Indexable : IIndexable
    {
        protected Indexable(string key)
        {
            Key = key;
        }

        public string Key
        {
            get; private set;
        }
    }
}
