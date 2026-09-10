// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.HybridContainerService
{
    public partial class HybridContainerServiceAgentPoolResource
    {
        private const string TagsNotSupportedMessage = "The resource currently doesn't support tags property.";

        // AutoRest previously synthesized tag helpers for this proxy resource. The service schema
        // has no tags property, so retain the shipped methods as hidden compatibility stubs.
        /// <summary> Adds a tag to this resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="NotSupportedException"> The resource does not support tags. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridContainerServiceAgentPoolResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(TagsNotSupportedMessage);

        /// <summary> Adds a tag to this resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="NotSupportedException"> The resource does not support tags. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridContainerServiceAgentPoolResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(TagsNotSupportedMessage);

        /// <summary> Replaces the tags on this resource. </summary>
        /// <param name="tags"> The replacement tags. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="NotSupportedException"> The resource does not support tags. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridContainerServiceAgentPoolResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(TagsNotSupportedMessage);

        /// <summary> Replaces the tags on this resource. </summary>
        /// <param name="tags"> The replacement tags. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="NotSupportedException"> The resource does not support tags. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridContainerServiceAgentPoolResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(TagsNotSupportedMessage);

        /// <summary> Removes a tag from this resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="NotSupportedException"> The resource does not support tags. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridContainerServiceAgentPoolResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(TagsNotSupportedMessage);

        /// <summary> Removes a tag from this resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="NotSupportedException"> The resource does not support tags. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridContainerServiceAgentPoolResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(TagsNotSupportedMessage);
    }
}
