// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.Azure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Resource.Fluent
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
            IPage<Management.Resource.Fluent.Models.SubscriptionInner> firstPage = innerCollection.List();
            var innerList = new PagedList<Management.Resource.Fluent.Models.SubscriptionInner>(firstPage, (string nextPageLink) =>
            {
                return innerCollection.ListNext(nextPageLink);
            });

            return new PagedList<ISubscription>(new WrappedPage<Management.Resource.Fluent.Models.SubscriptionInner, ISubscription>(innerList.CurrentPage, WrapModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<Management.Resource.Fluent.Models.SubscriptionInner, ISubscription>(innerList.CurrentPage, WrapModel);
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

        private ISubscription WrapModel(Management.Resource.Fluent.Models.SubscriptionInner innerModel)
        {
            return new SubscriptionImpl(innerModel, innerCollection);
        }
    }
}