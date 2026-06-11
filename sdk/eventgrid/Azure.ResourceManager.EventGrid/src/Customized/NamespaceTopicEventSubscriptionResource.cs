// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class NamespaceTopicEventSubscriptionResource
    {
        [ForwardsClientCalls]
        public virtual async Task<Response<NamespaceTopicEventSubscriptionResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            NamespaceTopicEventSubscriptionPatch patch = await CreateTagPatchAsync(cancellationToken).ConfigureAwait(false);
            patch.Tags[key] = value;

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        [ForwardsClientCalls]
        public virtual Response<NamespaceTopicEventSubscriptionResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            NamespaceTopicEventSubscriptionPatch patch = CreateTagPatch(cancellationToken);
            patch.Tags[key] = value;

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<NamespaceTopicEventSubscriptionResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            NamespaceTopicEventSubscriptionPatch patch = new NamespaceTopicEventSubscriptionPatch();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        [ForwardsClientCalls]
        public virtual Response<NamespaceTopicEventSubscriptionResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            NamespaceTopicEventSubscriptionPatch patch = new NamespaceTopicEventSubscriptionPatch();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<NamespaceTopicEventSubscriptionResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            NamespaceTopicEventSubscriptionPatch patch = await CreateTagPatchAsync(cancellationToken).ConfigureAwait(false);
            patch.Tags.Remove(key);

            ArmOperation<NamespaceTopicEventSubscriptionResource> result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        [ForwardsClientCalls]
        public virtual Response<NamespaceTopicEventSubscriptionResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

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
#pragma warning restore CS1591
}
