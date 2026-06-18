// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// GA API compatibility: The old SDK exposed Get/Reconcile with a split (perimeterGuid, associationName) signature
// and a two-argument CreateResourceIdentifier. These partial methods provide the legacy overloads on top of the
// generated single-argument methods. They cannot be removed without breaking the shipped GA surface.

#nullable disable

#pragma warning disable CS1591

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class TopicNetworkSecurityPerimeterConfigurationResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName)
        {
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, resourceName, $"{perimeterGuid}.{associationName}");
        }

        public virtual Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return Get(perimeterGuid, associationName, cancellationToken);
        }

        public virtual async Task<ArmOperation<TopicNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation = await NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id)
                .ReconcileAsync(waitUntil, NetworkSecurityPerimeterResourceType.Topics, Id.Parent.Name, perimeterGuid, associationName, cancellationToken)
                .ConfigureAwait(false);
            return new NetworkSecurityPerimeterConfigurationCompatOperation<TopicNetworkSecurityPerimeterConfigurationResource>(operation, data => new TopicNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        public virtual ArmOperation<TopicNetworkSecurityPerimeterConfigurationResource> Reconcile(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation = NetworkSecurityPerimeterConfigurationCompat.GetResourceGroup(Client, Id)
                .Reconcile(waitUntil, NetworkSecurityPerimeterResourceType.Topics, Id.Parent.Name, perimeterGuid, associationName, cancellationToken);
            return new NetworkSecurityPerimeterConfigurationCompatOperation<TopicNetworkSecurityPerimeterConfigurationResource>(operation, data => new TopicNetworkSecurityPerimeterConfigurationResource(Client, data));
        }
    }
}
#pragma warning restore CS1591
