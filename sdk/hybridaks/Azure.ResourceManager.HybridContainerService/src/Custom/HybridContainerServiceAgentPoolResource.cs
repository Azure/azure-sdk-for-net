// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.HybridContainerService
{
    // The TypeSpec resource omits the GA tags envelope, so tag convenience methods are restored through full-resource updates.
    public partial class HybridContainerServiceAgentPoolResource
    {
        /// <summary> Add a tag to the resource. </summary>
        public virtual Response<HybridContainerServiceAgentPoolResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            HybridContainerServiceAgentPoolData data = Get(cancellationToken: cancellationToken).Value.Data;
            data.Tags[key] = value;
            ArmOperation<HybridContainerServiceAgentPoolResource> operation = Update(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Add a tag to the resource. </summary>
        public virtual async Task<Response<HybridContainerServiceAgentPoolResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Response<HybridContainerServiceAgentPoolResource> current = await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            current.Value.Data.Tags[key] = value;
            ArmOperation<HybridContainerServiceAgentPoolResource> operation = await UpdateAsync(WaitUntil.Completed, current.Value.Data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Remove a tag from the resource. </summary>
        public virtual Response<HybridContainerServiceAgentPoolResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            HybridContainerServiceAgentPoolData data = Get(cancellationToken: cancellationToken).Value.Data;
            data.Tags.Remove(key);
            ArmOperation<HybridContainerServiceAgentPoolResource> operation = Update(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Remove a tag from the resource. </summary>
        public virtual async Task<Response<HybridContainerServiceAgentPoolResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            Response<HybridContainerServiceAgentPoolResource> current = await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            current.Value.Data.Tags.Remove(key);
            ArmOperation<HybridContainerServiceAgentPoolResource> operation = await UpdateAsync(WaitUntil.Completed, current.Value.Data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<HybridContainerServiceAgentPoolResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            HybridContainerServiceAgentPoolData data = Get(cancellationToken: cancellationToken).Value.Data;
            data.Tags.Clear();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                data.Tags.Add(tag);
            }
            ArmOperation<HybridContainerServiceAgentPoolResource> operation = Update(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual async Task<Response<HybridContainerServiceAgentPoolResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            Response<HybridContainerServiceAgentPoolResource> current = await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            current.Value.Data.Tags.Clear();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                current.Value.Data.Tags.Add(tag);
            }
            ArmOperation<HybridContainerServiceAgentPoolResource> operation = await UpdateAsync(WaitUntil.Completed, current.Value.Data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}
