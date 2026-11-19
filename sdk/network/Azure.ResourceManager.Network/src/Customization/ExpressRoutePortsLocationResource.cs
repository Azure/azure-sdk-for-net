// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRoutePortsLocationResource
    {
        // The released custom methods use ARM's tag resource, not a location update endpoint.
        /// <summary> Adds a tag to the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Response<ExpressRoutePortsLocationResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            var tagResource = GetTagResource();
            var originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues[key] = value;
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Removes a tag by key from the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Response<ExpressRoutePortsLocationResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            var tagResource = GetTagResource();
            var originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues.Remove(key);
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replaces the tags on the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Response<ExpressRoutePortsLocationResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
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

        /// <summary> Adds a tag to the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ExpressRoutePortsLocationResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            var tagResource = GetTagResource();
            var originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues[key] = value;
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Removes a tag by key from the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ExpressRoutePortsLocationResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            var tagResource = GetTagResource();
            var originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues.Remove(key);
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replaces the tags on the current resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ExpressRoutePortsLocationResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
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
