// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: the generated NSP Resource exposes
    // Get/Reconcile that still take the upstream (perimeterGuid, associationName)
    // pair instead of binding them from Id, and the static CreateResourceIdentifier
    // combines them into a single "{perimeterGuid}.{associationName}" segment.
    // We restore the back-compat surface (Get(ct), Reconcile(WaitUntil, ct), 5-arg
    // CreateResourceIdentifier) by deriving the two pieces from Id.Name.)
    public partial class TopicNetworkSecurityPerimeterConfigurationResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="resourceName"> The resourceName. </param>
        /// <param name="perimeterGuid"> The perimeterGuid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName)
        {
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, resourceName, $"{perimeterGuid}.{associationName}");
        }

        /// <summary> Get a specific network security perimeter configuration with a topic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = SplitName(Id.Name);
            return GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Get a specific network security perimeter configuration with a topic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = SplitName(Id.Name);
            return Get(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Reconcile a specific network security perimeter configuration with a topic. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<TopicNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = SplitName(Id.Name);
            return ReconcileAsync(waitUntil, perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Reconcile a specific network security perimeter configuration with a topic. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<TopicNetworkSecurityPerimeterConfigurationResource> Reconcile(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = SplitName(Id.Name);
            return Reconcile(waitUntil, perimeterGuid, associationName, cancellationToken);
        }

        private static (string PerimeterGuid, string AssociationName) SplitName(string combinedName)
        {
            if (string.IsNullOrEmpty(combinedName))
            {
                throw new InvalidOperationException("Resource Id.Name is empty; expected '{perimeterGuid}.{associationName}'.");
            }
            int dotIndex = combinedName.IndexOf('.');
            if (dotIndex <= 0 || dotIndex >= combinedName.Length - 1)
            {
                throw new InvalidOperationException($"Resource Id.Name '{combinedName}' is not in the '{{perimeterGuid}}.{{associationName}}' format.");
            }
            return (combinedName.Substring(0, dotIndex), combinedName.Substring(dotIndex + 1));
        }
    }
}
