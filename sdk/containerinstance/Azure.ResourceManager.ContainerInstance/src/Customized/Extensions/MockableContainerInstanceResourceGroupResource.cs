// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceResourceGroupResource
    {
        // backward-compat shim: old name was GetContainerGroupProfiles()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerGroupProfileCollection GetContainerGroupProfiles()
            => throw new NotSupportedException("Backward compat shim - use GetCGProfiles() instead.");

        // backward-compat shim: old name was GetContainerGroupProfile()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerGroupProfileResource> GetContainerGroupProfile(string containerGroupProfileName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use GetCGProfile() instead.");

        // backward-compat shim: old name was GetContainerGroupProfileAsync()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerGroupProfileResource>> GetContainerGroupProfileAsync(string containerGroupProfileName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use GetCGProfileAsync() instead.");

        // backward-compat shim: old name was DeleteSubnetServiceAssociationLink()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation DeleteSubnetServiceAssociationLink(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - DeleteSubnetServiceAssociationLink has been moved.");

        // backward-compat shim: old name was DeleteSubnetServiceAssociationLinkAsync()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - DeleteSubnetServiceAssociationLinkAsync has been moved.");
    }
}
