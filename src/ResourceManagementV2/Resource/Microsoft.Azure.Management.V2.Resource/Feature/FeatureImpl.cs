using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class FeatureImpl : IndexableWrapper<FeatureResultInner>,
        IFeature
    {
        internal FeatureImpl(FeatureResultInner innerModel) : base(innerModel.Id, innerModel) { }

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string State
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.State;
            }
        }

        public string Type
        {
            get
            {
                return Inner.Type;
            }
        }
    }
}
