// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore legacy tag helpers removed when latest generation no longer emits them for this resource.
    public partial class MachineLearningServerlessEndpointResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        public virtual Task<Response<MachineLearningServerlessEndpointResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => MachineLearningTagOperationHelpers.AddTagAsync(GetTagResource(), GetAsync, key, value, cancellationToken);

        /// <summary> Add a tag to the current resource. </summary>
        public virtual Response<MachineLearningServerlessEndpointResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => MachineLearningTagOperationHelpers.AddTag(GetTagResource(), Get, key, value, cancellationToken);

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Task<Response<MachineLearningServerlessEndpointResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => MachineLearningTagOperationHelpers.SetTagsAsync(GetTagResource(), GetAsync, tags, cancellationToken);

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<MachineLearningServerlessEndpointResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => MachineLearningTagOperationHelpers.SetTags(GetTagResource(), Get, tags, cancellationToken);

        /// <summary> Remove a tag from the current resource. </summary>
        public virtual Task<Response<MachineLearningServerlessEndpointResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => MachineLearningTagOperationHelpers.RemoveTagAsync(GetTagResource(), GetAsync, key, cancellationToken);

        /// <summary> Remove a tag from the current resource. </summary>
        public virtual Response<MachineLearningServerlessEndpointResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => MachineLearningTagOperationHelpers.RemoveTag(GetTagResource(), Get, key, cancellationToken);
    }
}
