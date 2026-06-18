// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class DomainNetworkSecurityPerimeterConfigurationResource
    {
        /// <summary> Creates a resource identifier for a domain network security perimeter configuration resource. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="resourceName"> The resource name. </param>
        /// <param name="perimeterGuid"> The network security perimeter GUID. </param>
        /// <param name="associationName"> The network security perimeter association name. </param>
        /// <returns> The resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName)
        {
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, resourceName, $"{perimeterGuid}.{associationName}");
        }

        /// <summary> Gets this network security perimeter configuration resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        public virtual Task<Response<DomainNetworkSecurityPerimeterConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Gets this network security perimeter configuration resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        public virtual Response<DomainNetworkSecurityPerimeterConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return Get(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Reconciles this network security perimeter configuration resource. </summary>
        /// <param name="waitUntil"> The condition to wait for before the operation completes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation to reconcile the resource. </returns>
        public virtual async Task<ArmOperation<DomainNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation = await NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id)
                .ReconcileAsync(waitUntil, NetworkSecurityPerimeterResourceType.Domains, Id.Parent.Name, perimeterGuid, associationName, cancellationToken)
                .ConfigureAwait(false);
            return new NetworkSecurityPerimeterConfigurationCompatOperation<DomainNetworkSecurityPerimeterConfigurationResource>(operation, data => new DomainNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        /// <summary> Reconciles this network security perimeter configuration resource. </summary>
        /// <param name="waitUntil"> The condition to wait for before the operation completes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation to reconcile the resource. </returns>
        public virtual ArmOperation<DomainNetworkSecurityPerimeterConfigurationResource> Reconcile(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation = NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id)
                .Reconcile(waitUntil, NetworkSecurityPerimeterResourceType.Domains, Id.Parent.Name, perimeterGuid, associationName, cancellationToken);
            return new NetworkSecurityPerimeterConfigurationCompatOperation<DomainNetworkSecurityPerimeterConfigurationResource>(operation, data => new DomainNetworkSecurityPerimeterConfigurationResource(Client, data));
        }
    }
}
