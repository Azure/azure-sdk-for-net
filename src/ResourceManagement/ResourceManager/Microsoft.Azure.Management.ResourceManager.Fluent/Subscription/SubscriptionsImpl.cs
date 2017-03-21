// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
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
            IPage<SubscriptionInner> firstPage = innerCollection.List();
            var innerList = new PagedList<SubscriptionInner>(firstPage, (string nextPageLink) =>
            {
                return innerCollection.ListNext(nextPageLink);
            });

            return new PagedList<ISubscription>(new WrappedPage<SubscriptionInner, ISubscription>(innerList.CurrentPage, WrapModel),
            (string nextPageLink) =>
            {
                innerList.LoadNextPage();
                return new WrappedPage<SubscriptionInner, ISubscription>(innerList.CurrentPage, WrapModel);
            });
        }

        public ISubscription GetById(string id)
        {
            var inner = innerCollection.Get(id);
            if (inner == null)
            {
                return null;
            }
            else
            {
                return new SubscriptionImpl(inner, innerCollection);
            }
        }

        public Task<ISubscription> GetByIdAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        private ISubscription WrapModel(SubscriptionInner innerModel)
        {
            return new SubscriptionImpl(innerModel, innerCollection);
        }
    }
}