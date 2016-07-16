using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Resource
{
    public interface ISubscription :
        IIndexable,
        IWrapper<Management.ResourceManager.Models.Subscription>
    {
        string SubscriptionId { get; }

        string DisplayName { get; }

        string State { get; }

        Management.ResourceManager.Models.SubscriptionPolicies SubscriptionPolicies { get; }

        PagedList<Management.ResourceManager.Models.Location> ListLocations();
    }
}
