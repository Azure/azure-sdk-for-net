// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventGridTopicResource
    {
        /// <summary> Add a tag to the resource. </summary>
        public virtual async Task<Response<EventGridTopicResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            EventGridTopicPatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags[key] = value;
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Add a tag to the resource. </summary>
        public virtual Response<EventGridTopicResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            EventGridTopicPatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags[key] = value;
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Remove a tag from the resource. </summary>
        public virtual async Task<Response<EventGridTopicResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            EventGridTopicPatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags.Remove(key);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Remove a tag from the resource. </summary>
        public virtual Response<EventGridTopicResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            EventGridTopicPatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags.Remove(key);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replace the resource tags. </summary>
        public virtual async Task<Response<EventGridTopicResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            EventGridTopicPatch patch = CreatePatchWithTags(tags);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replace the resource tags. </summary>
        public virtual Response<EventGridTopicResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            EventGridTopicPatch patch = CreatePatchWithTags(tags);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        private static EventGridTopicPatch CreatePatchWithTags(IDictionary<string, string> tags)
        {
            EventGridTopicPatch patch = new EventGridTopicPatch();
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
