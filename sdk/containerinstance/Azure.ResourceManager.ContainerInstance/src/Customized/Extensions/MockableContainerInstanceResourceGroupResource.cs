// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shim methods for MockableContainerInstanceResourceGroupResource (ApiCompat MembersMustExist).
// Preserves old method signatures that delegate to renamed generated methods.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    /// <summary> Backward-compat shim methods for MockableContainerInstanceResourceGroupResource. </summary>
    public partial class MockableContainerInstanceResourceGroupResource
    {
        /// <summary> Gets the container group profiles collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerGroupProfileCollection GetContainerGroupProfiles()
        {
            return GetCachedClient(client => new ContainerGroupProfileCollection(client, Id));
        }

        /// <summary> Gets a container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerGroupProfileResource> GetContainerGroupProfile(string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = GetCGProfile(containerGroupProfileName, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets a container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerGroupProfileResource>> GetContainerGroupProfileAsync(string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await GetCGProfileAsync(containerGroupProfileName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets a container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerGroupResource> GetContainerGroup(string containerGroupName, CancellationToken cancellationToken = default)
        {
            return GetContainerGroups().Get(containerGroupName, cancellationToken);
        }

        /// <summary> Gets a container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerGroupResource>> GetContainerGroupAsync(string containerGroupName, CancellationToken cancellationToken = default)
        {
            return await GetContainerGroups().GetAsync(containerGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete the subnet service association link for the subnet. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation DeleteSubnetServiceAssociationLink(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            var subscriptionMockable = GetCachedClient(client =>
                new MockableContainerInstanceSubscriptionResource(client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}")));
            return subscriptionMockable.Delete(waitUntil, Id.Name, virtualNetworkName, subnetName, cancellationToken);
        }

        /// <summary> Delete the subnet service association link for the subnet. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            var subscriptionMockable = GetCachedClient(client =>
                new MockableContainerInstanceSubscriptionResource(client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}")));
            return await subscriptionMockable.DeleteAsync(waitUntil, Id.Name, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
        }
    }
}
