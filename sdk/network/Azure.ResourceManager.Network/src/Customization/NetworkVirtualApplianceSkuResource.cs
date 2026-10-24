// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceSkuResource
    {
        // 1.15.0 supplied this obsolete method through ARM's tag resource, not a SKU update operation.
        /// <summary> Adds a tag using the ARM tag resource and refreshes the SKU resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkVirtualApplianceSkuResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            var tagResource = GetTagResource();
            var originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues[key] = value;
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return Get(cancellationToken);
        }

        // Preserve the asynchronous 1.15.0 ARM tag-resource implementation and released metadata.
        /// <summary> Adds a tag using the ARM tag resource and refreshes the SKU resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetworkVirtualApplianceSkuResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            var tagResource = GetTagResource();
            var originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues[key] = value;
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        // 1.15.0 removed tags through ARM's tag resource even though the SKU itself has no update operation.
        /// <summary> Removes a tag using the ARM tag resource and refreshes the SKU resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkVirtualApplianceSkuResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            var tagResource = GetTagResource();
            var originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues.Remove(key);
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return Get(cancellationToken);
        }

        // Preserve the asynchronous 1.15.0 tag-removal contract without inventing a SKU update endpoint.
        /// <summary> Removes a tag using the ARM tag resource and refreshes the SKU resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetworkVirtualApplianceSkuResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            var tagResource = GetTagResource();
            var originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues.Remove(key);
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        // Preserve the 1.15.0 delete/read/replace sequence on the separate ARM tag resource.
        /// <summary> Replaces the resource tags using the ARM tag resource and refreshes the SKU resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkVirtualApplianceSkuResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            var tagResource = GetTagResource();
            tagResource.Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
            var originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues.Clear();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                originalTags.Value.Data.TagValues.Add(tag);
            }
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return Get(cancellationToken);
        }

        // Preserve the asynchronous 1.15.0 tag-replacement sequence and final native resource response.
        /// <summary> Replaces the resource tags using the ARM tag resource and refreshes the SKU resource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetworkVirtualApplianceSkuResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            var tagResource = GetTagResource();
            await tagResource.DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
            var originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues.Clear();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                originalTags.Value.Data.TagValues.Add(tag);
            }
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
