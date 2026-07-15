// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    // Tag add/remove/set helpers: unlike the tracked EventGrid resources, this resource's PATCH does return
    // content, but its tags live at properties.tags (nested). The generator only recognizes a top-level "tags"
    // property when deciding whether to emit the standard ARM tag operations, so it skips them for this nested
    // layout. They are hand-authored here to preserve main's GA tag surface.
    public partial class NamespaceTopicEventSubscriptionResource
    {
        /// <summary> Adds a tag to the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<NamespaceTopicEventSubscriptionResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
            {
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                return await GetAsync(cancellationToken).ConfigureAwait(false);
            }

            NamespaceTopicEventSubscriptionPatch patch = await CreateTagPatchAsync(cancellationToken).ConfigureAwait(false);
            patch.Tags[key] = value;

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary> Adds a tag to the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<NamespaceTopicEventSubscriptionResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            if (CanUseTagResource(cancellationToken))
            {
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                return Get(cancellationToken);
            }

            NamespaceTopicEventSubscriptionPatch patch = CreateTagPatch(cancellationToken);
            patch.Tags[key] = value;

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary> Replaces the resource tags. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<NamespaceTopicEventSubscriptionResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
            {
                await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                return await GetAsync(cancellationToken).ConfigureAwait(false);
            }

            NamespaceTopicEventSubscriptionPatch patch = new NamespaceTopicEventSubscriptionPatch();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary> Replaces the resource tags. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<NamespaceTopicEventSubscriptionResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            if (CanUseTagResource(cancellationToken))
            {
                GetTagResource().Delete(WaitUntil.Completed, cancellationToken);
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                return Get(cancellationToken);
            }

            NamespaceTopicEventSubscriptionPatch patch = new NamespaceTopicEventSubscriptionPatch();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary> Removes a tag from the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<NamespaceTopicEventSubscriptionResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
            {
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                return await GetAsync(cancellationToken).ConfigureAwait(false);
            }

            NamespaceTopicEventSubscriptionPatch patch = await CreateTagPatchAsync(cancellationToken).ConfigureAwait(false);
            patch.Tags.Remove(key);

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary> Removes a tag from the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<NamespaceTopicEventSubscriptionResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            if (CanUseTagResource(cancellationToken))
            {
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                return Get(cancellationToken);
            }

            NamespaceTopicEventSubscriptionPatch patch = CreateTagPatch(cancellationToken);
            patch.Tags.Remove(key);

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        private async Task<NamespaceTopicEventSubscriptionPatch> CreateTagPatchAsync(CancellationToken cancellationToken)
        {
            NamespaceTopicEventSubscriptionData current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
            return CreateTagPatch(current);
        }

        private NamespaceTopicEventSubscriptionPatch CreateTagPatch(CancellationToken cancellationToken)
        {
            NamespaceTopicEventSubscriptionData current = Get(cancellationToken).Value.Data;
            return CreateTagPatch(current);
        }

        private static NamespaceTopicEventSubscriptionPatch CreateTagPatch(NamespaceTopicEventSubscriptionData current)
        {
            NamespaceTopicEventSubscriptionPatch patch = new NamespaceTopicEventSubscriptionPatch();
            foreach (KeyValuePair<string, string> tag in current.Tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }
            return patch;
        }
    }
}
