// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat alias: ContainerGroupProfileResource was renamed to CGProfileResource in TypeSpec migration.
    /// <summary> A class representing the ContainerGroupProfile resource along with operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileResource : CGProfileResource
    {
        // backward-compat shim: old static ResourceType field
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly ResourceType ResourceType = "Microsoft.ContainerInstance/containerGroupProfiles";

        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileResource"/>. </summary>
        protected ContainerGroupProfileResource()
        {
        }

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileResource(bool _)
        {
        }

        // backward-compat shim: old static CreateResourceIdentifier method
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerGroupProfileName)
            => CGProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, containerGroupProfileName);

        // backward-compat shim: old return type was Response<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> Get(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.Get() instead.");

        // backward-compat shim: old return type was Task<Response<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<Response<ContainerGroupProfileResource>> GetAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetAsync() instead.");

        // backward-compat shim: old return type was Response<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> Update(ContainerGroupProfilePatch patch, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.Update() instead.");

        // backward-compat shim: old return type was Task<Response<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<Response<ContainerGroupProfileResource>> UpdateAsync(ContainerGroupProfilePatch patch, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.UpdateAsync() instead.");

        // backward-compat shim: old return type was Response<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.AddTag() instead.");

        // backward-compat shim: old return type was Task<Response<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<Response<ContainerGroupProfileResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.AddTagAsync() instead.");

        // backward-compat shim: old return type was Response<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.SetTags() instead.");

        // backward-compat shim: old return type was Task<Response<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<Response<ContainerGroupProfileResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.SetTagsAsync() instead.");

        // backward-compat shim: old return type was Response<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.RemoveTag() instead.");

        // backward-compat shim: old return type was Task<Response<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<Response<ContainerGroupProfileResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.RemoveTagAsync() instead.");

        // backward-compat shim: old name was GetContainerGroupProfileRevisions()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerGroupProfileRevisionCollection GetContainerGroupProfileRevisions()
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles() instead.");

        // backward-compat shim: old name was GetContainerGroupProfileRevision()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerGroupProfileRevisionResource> GetContainerGroupProfileRevision(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfile() instead.");

        // backward-compat shim: old name was GetContainerGroupProfileRevisionAsync()
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerGroupProfileRevisionResource>> GetContainerGroupProfileRevisionAsync(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfileAsync() instead.");
    }
}
