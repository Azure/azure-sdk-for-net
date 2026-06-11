// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class TopicNetworkSecurityPerimeterConfigurationCollection : IEnumerable<NetworkSecurityPerimeterConfigurationData>, IAsyncEnumerable<NetworkSecurityPerimeterConfigurationData>
    {
        public virtual AsyncPageable<NetworkSecurityPerimeterConfigurationData> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id).GetAllAsync(NetworkSecurityPerimeterResourceType.Topics, Id.Name, cancellationToken);
        }

        public virtual Pageable<NetworkSecurityPerimeterConfigurationData> GetAll(CancellationToken cancellationToken = default)
        {
            return NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id).GetAll(NetworkSecurityPerimeterResourceType.Topics, Id.Name, cancellationToken);
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
