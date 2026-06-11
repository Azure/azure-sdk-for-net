// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class PartnerNamespaceResource
    {
        /// <summary> Adds a tag to the resource. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespaceResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags[key] = value;
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Adds a tag to the resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespaceResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags[key] = value;
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Removes a tag from the resource. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespaceResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags.Remove(key);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Removes a tag from the resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespaceResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags.Remove(key);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replaces the resource tags. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespaceResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            PartnerNamespacePatch patch = CreatePatchWithTags(tags);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replaces the resource tags. </summary>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespaceResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            PartnerNamespacePatch patch = CreatePatchWithTags(tags);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        private static PartnerNamespacePatch CreatePatchWithTags(IDictionary<string, string> tags)
        {
            PartnerNamespacePatch patch = new PartnerNamespacePatch();
            if (tags is null)
            {
                return patch;
            }

            foreach (KeyValuePair<string, string> tag in tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }

            return patch;
        }
    }
}
