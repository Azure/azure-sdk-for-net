// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public partial class DomainNetworkSecurityPerimeterConfigurationCollection : IEnumerable<NetworkSecurityPerimeterConfigurationData>, IAsyncEnumerable<NetworkSecurityPerimeterConfigurationData>
    {
        public virtual AsyncPageable<NetworkSecurityPerimeterConfigurationData> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT(
                _networkSecurityPerimeterConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                NetworkSecurityPerimeterResourceType.Domains.ToString(),
                Id.Name,
                context,
                "DomainNetworkSecurityPerimeterConfigurationCollection.GetAll");
        }

        public virtual Pageable<NetworkSecurityPerimeterConfigurationData> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT(
                _networkSecurityPerimeterConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                NetworkSecurityPerimeterResourceType.Domains.ToString(),
                Id.Name,
                context,
                "DomainNetworkSecurityPerimeterConfigurationCollection.GetAll");
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
