// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        /// <summary> Gets all network security perimeter configurations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A pageable sequence of resources. </returns>
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

        /// <summary> Gets all network security perimeter configurations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A pageable sequence of resources. </returns>
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

        /// <summary> Gets an async enumerator for the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        public virtual IAsyncEnumerator<NetworkSecurityPerimeterConfigurationData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets an enumerator for the collection. </summary>
        /// <returns> The requested resource. </returns>
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
