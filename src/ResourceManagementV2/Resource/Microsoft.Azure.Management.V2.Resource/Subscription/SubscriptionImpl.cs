using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class SubscriptionImpl :
        IndexableWrapper<Management.ResourceManager.Models.Subscription>,
        ISubscription
    {
        private ISubscriptionsOperations innerCollection;

        internal SubscriptionImpl(Management.ResourceManager.Models.Subscription innerModel, ISubscriptionsOperations client) : base(innerModel.Id, innerModel)
        {
            innerCollection = client;
        }

        public string DisplayName
        {
            get
            {
                return Inner.DisplayName;
            }
        }

        public string State
        {
            get
            {
                return Inner.State;
            }
        }

        public string SubscriptionId
        {
            get
            {
                return Inner.SubscriptionId;
            }
        }

        public SubscriptionPolicies SubscriptionPolicies
        {
            get
            {
                return Inner.SubscriptionPolicies;
            }
        }

        public PagedList<Location> ListLocations()
        {
            IEnumerable<Location> firstPage = innerCollection.ListLocations(this.SubscriptionId);
            return new PagedList<Location>(firstPage);
        }
    }
}
