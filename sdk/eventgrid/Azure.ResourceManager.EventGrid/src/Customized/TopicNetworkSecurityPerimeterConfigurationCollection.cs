// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// GA API compatibility: The old SDK collection exposed GetAll/GetEnumerator returning
// NetworkSecurityPerimeterConfigurationData directly. The generated collection uses a different
// scope pattern, so these partial methods provide the legacy enumeration surface.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class TopicNetworkSecurityPerimeterConfigurationCollection : IEnumerable<NetworkSecurityPerimeterConfigurationData>, IAsyncEnumerable<NetworkSecurityPerimeterConfigurationData>
    {
        public virtual AsyncPageable<NetworkSecurityPerimeterConfigurationData> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT(
                _networkSecurityPerimeterConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                NetworkSecurityPerimeterResourceType.Topics.ToString(),
                Id.Name,
                context,
                "TopicNetworkSecurityPerimeterConfigurationCollection.GetAll");
        }

        public virtual Pageable<NetworkSecurityPerimeterConfigurationData> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT(
                _networkSecurityPerimeterConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                NetworkSecurityPerimeterResourceType.Topics.ToString(),
                Id.Name,
                context,
                "TopicNetworkSecurityPerimeterConfigurationCollection.GetAll");
        }

        public virtual IAsyncEnumerator<NetworkSecurityPerimeterConfigurationData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        public virtual IEnumerator<NetworkSecurityPerimeterConfigurationData> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
#pragma warning restore CS1591
