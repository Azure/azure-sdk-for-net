// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class RestorableDroppedManagedDatabaseResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RestorableDroppedManagedDatabaseResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Adding tags is not supported on this resource.");
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<RestorableDroppedManagedDatabaseResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Adding tags is not supported on this resource.");
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RestorableDroppedManagedDatabaseResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Setting tags is not supported on this resource.");
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<RestorableDroppedManagedDatabaseResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Setting tags is not supported on this resource.");
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RestorableDroppedManagedDatabaseResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Removing tags is not supported on this resource.");
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<RestorableDroppedManagedDatabaseResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Removing tags is not supported on this resource.");
        }
    }
}
