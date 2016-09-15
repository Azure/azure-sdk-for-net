using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest.Azure;
using System;
using System.Threading;
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

        public PagedList<ISubscription> List()
        {
            IPage<Management.ResourceManager.Models.SubscriptionInner> firstPage = innerCollection.List();
            var innerList = new PagedList<Management.ResourceManager.Models.SubscriptionInner>(firstPage, (string nextPageLink) =>
            {
                return innerCollection.ListNext(nextPageLink);
            });

            return new PagedList<ISubscription>(new WrappedPage<Management.ResourceManager.Models.SubscriptionInner, ISubscription>(innerList.CurrentPage, WrapModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<Management.ResourceManager.Models.SubscriptionInner, ISubscription>(innerList.CurrentPage, WrapModel);
            });
        }

        public ISubscription GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ISubscription> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        private ISubscription WrapModel(Management.ResourceManager.Models.SubscriptionInner innerModel)
        {
            return new SubscriptionImpl(innerModel, innerCollection);
        }
    }
}