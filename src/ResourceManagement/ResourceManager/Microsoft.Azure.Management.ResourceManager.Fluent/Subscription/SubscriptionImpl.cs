// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Management.Fluent.Resource;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    internal class SubscriptionImpl :
        IndexableWrapper<Management.Resource.Fluent.Models.SubscriptionInner>,
        ISubscription
    {
        private ISubscriptionsOperations innerCollection;

        internal SubscriptionImpl(Management.Resource.Fluent.Models.SubscriptionInner innerModel, ISubscriptionsOperations client) : base(innerModel)
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

        public ILocation GetLocationByRegion(Region region)
        {
            if (region != null)
            {
                var locations = ListLocations();
                foreach (var location in locations)
                {
                    if (region.Equals(location.Region))
                    {
                        return location;
                    }
                }
            }
            return null;
        }

        public PagedList<ILocation> ListLocations()
        {
            var innerList = new PagedList<LocationInner>(innerCollection.ListLocations(SubscriptionId));
            return PagedListConverter.Convert<LocationInner, ILocation>(innerList, innerLocation => {
                return new LocationImpl(innerLocation); 
            });
        }
    }
}
