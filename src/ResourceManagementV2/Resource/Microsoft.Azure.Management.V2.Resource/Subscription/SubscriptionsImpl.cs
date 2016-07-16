using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest.Azure;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class SubscriptionsImpl :
        ISubscriptions
    {
        private ISubscriptionsOperations innerCollection;

        internal SubscriptionsImpl(ISubscriptionsOperations client)
        {
            this.innerCollection = client;
        }

        public Task<ISubscription> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public PagedList<ISubscription> List()
        {
            IPage<Management.ResourceManager.Models.Subscription> firstPage = innerCollection.List();
            var innerList = new PagedList<Management.ResourceManager.Models.Subscription>(firstPage, (string nextPageLink) =>
            {
                return innerCollection.ListNext(nextPageLink);
            });

            return new PagedList<ISubscription>(new WrappedPage<Management.ResourceManager.Models.Subscription, ISubscription>(innerList.CurrentPage, WrapModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<Management.ResourceManager.Models.Subscription, ISubscription>(innerList.CurrentPage, WrapModel);
            });
        }

        private ISubscription WrapModel(Management.ResourceManager.Models.Subscription innerModel)
        {
            return new SubscriptionImpl(innerModel, innerCollection);
        }
    }
}
