// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class DomainNetworkSecurityPerimeterConfigurationResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName)
        {
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, resourceName, $"{perimeterGuid}.{associationName}");
        }

        public virtual Task<Response<DomainNetworkSecurityPerimeterConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        public virtual Response<DomainNetworkSecurityPerimeterConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return Get(perimeterGuid, associationName, cancellationToken);
        }

        public virtual async Task<ArmOperation<DomainNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation = await NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id)
                .ReconcileAsync(waitUntil, NetworkSecurityPerimeterResourceType.Domains, Id.Parent.Name, perimeterGuid, associationName, cancellationToken)
                .ConfigureAwait(false);
            return new NetworkSecurityPerimeterConfigurationCompatOperation<DomainNetworkSecurityPerimeterConfigurationResource>(operation, data => new DomainNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        public virtual ArmOperation<DomainNetworkSecurityPerimeterConfigurationResource> Reconcile(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation = NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id)
                .Reconcile(waitUntil, NetworkSecurityPerimeterResourceType.Domains, Id.Parent.Name, perimeterGuid, associationName, cancellationToken);
            return new NetworkSecurityPerimeterConfigurationCompatOperation<DomainNetworkSecurityPerimeterConfigurationResource>(operation, data => new DomainNetworkSecurityPerimeterConfigurationResource(Client, data));
        }
    }
}
#pragma warning restore CS1591
