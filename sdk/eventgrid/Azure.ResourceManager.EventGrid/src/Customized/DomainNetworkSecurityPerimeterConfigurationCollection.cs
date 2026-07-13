// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// SDK customization: data-returning GetAll + IEnumerable for the NSP config collection.
//
// WHY THIS CUSTOMIZATION EXISTS:
// On main, this collection's GetAll/GetAllAsync return NetworkSecurityPerimeterConfigurationData
// (the DATA model) directly, NOT the DomainNetworkSecurityPerimeterConfigurationResource. The new
// mgmt generator only emits a GetAll that wraps data into the collection's resource type, so it
// produces NO GetAll here (the generated collection is just ": ArmCollection" with Get/Exists/
// GetIfExists). This file supplies the data-returning GetAll (using the GENERATED
// NetworkSecurityPerimeterConfigurationsGetAll*CollectionResultOfT plumbing) plus the
// IEnumerable<...Data>/IAsyncEnumerable<...Data> implementation so the public surface matches main.
//
// The enumerators are EXPLICIT interface implementations (not public virtual) to exactly match
// main's generated shape; emitting them as public virtual would add extra public methods absent on main.

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
        IAsyncEnumerator<NetworkSecurityPerimeterConfigurationData> IAsyncEnumerable<NetworkSecurityPerimeterConfigurationData>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets an enumerator for the collection. </summary>
        /// <returns> The requested resource. </returns>
        IEnumerator<NetworkSecurityPerimeterConfigurationData> IEnumerable<NetworkSecurityPerimeterConfigurationData>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }
    }
}
