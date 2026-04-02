// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerInstance.Models;

// Backward-compat: type alias for renamed resource type (ApiCompat TypesMustExist)
// Old name: ContainerGroupProfileResource, New name: CGProfileResource

namespace Azure.ResourceManager.ContainerInstance
{
    /// <summary> Backward compatibility alias for <see cref="CGProfileResource"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileResource : CGProfileResource
    {
        /// <summary> Resource type of ContainerGroupProfileResource. </summary>
        public static new readonly ResourceType ResourceType = CGProfileResource.ResourceType;

        /// <summary> Initializes a new instance for mocking. </summary>
        protected ContainerGroupProfileResource()
        {
        }

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileResource(ArmClient client, ContainerGroupProfileData data) : base(client, data)
        {
        }

        /// <summary> Gets the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> Get(CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.Get(cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ContainerGroupProfileResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Add a tag to the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.AddTag(key, value, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Add a tag to the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ContainerGroupProfileResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.AddTagAsync(key, value, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Remove a tag from the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.RemoveTag(key, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Remove a tag from the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ContainerGroupProfileResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.RemoveTagAsync(key, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Replace the tags on the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.SetTags(tags, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Replace the tags on the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ContainerGroupProfileResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.SetTagsAsync(tags, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Update the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> Update(ContainerGroupProfilePatch patch, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.Update(patch, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Update the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ContainerGroupProfileResource>> UpdateAsync(ContainerGroupProfilePatch patch, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets the container group profile revisions collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerGroupProfileRevisionCollection GetContainerGroupProfileRevisions()
        {
            return GetCachedClient(client => new ContainerGroupProfileRevisionCollection(client, Id));
        }

        /// <summary> Gets a container group profile revision. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerGroupProfileRevisionResource> GetContainerGroupProfileRevision(string revisionNumber, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.GetCGProfile(revisionNumber, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileRevisionResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets a container group profile revision. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerGroupProfileRevisionResource>> GetContainerGroupProfileRevisionAsync(string revisionNumber, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.GetCGProfileAsync(revisionNumber, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileRevisionResource(Client, response.Value.Data), response.GetRawResponse());
        }
    }
}
