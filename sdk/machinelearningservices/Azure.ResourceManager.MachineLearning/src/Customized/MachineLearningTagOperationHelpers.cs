// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: shared implementation for GA tag helper methods restored on resources where the
    // TypeSpec generator no longer emits resource-specific AddTag/SetTags/RemoveTag methods.
    internal static class MachineLearningTagOperationHelpers
    {
        public static async Task<Response<T>> AddTagAsync<T>(TagResource tagResource, Func<CancellationToken, Task<Response<T>>> getAsync, string key, string value, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Response<TagResource> originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues[key] = value;
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await getAsync(cancellationToken).ConfigureAwait(false);
        }

        public static Response<T> AddTag<T>(TagResource tagResource, Func<CancellationToken, Response<T>> get, string key, string value, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Response<TagResource> originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues[key] = value;
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return get(cancellationToken);
        }

        public static async Task<Response<T>> SetTagsAsync<T>(TagResource tagResource, Func<CancellationToken, Task<Response<T>>> getAsync, IDictionary<string, string> tags, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            Response<TagResource> originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues.Clear();
            foreach (var tag in tags)
            {
                originalTags.Value.Data.TagValues[tag.Key] = tag.Value;
            }
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await getAsync(cancellationToken).ConfigureAwait(false);
        }

        public static Response<T> SetTags<T>(TagResource tagResource, Func<CancellationToken, Response<T>> get, IDictionary<string, string> tags, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            Response<TagResource> originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues.Clear();
            foreach (var tag in tags)
            {
                originalTags.Value.Data.TagValues[tag.Key] = tag.Value;
            }
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return get(cancellationToken);
        }

        public static async Task<Response<T>> RemoveTagAsync<T>(TagResource tagResource, Func<CancellationToken, Task<Response<T>>> getAsync, string key, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));

            Response<TagResource> originalTags = await tagResource.GetAsync(cancellationToken).ConfigureAwait(false);
            originalTags.Value.Data.TagValues.Remove(key);
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
            return await getAsync(cancellationToken).ConfigureAwait(false);
        }

        public static Response<T> RemoveTag<T>(TagResource tagResource, Func<CancellationToken, Response<T>> get, string key, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));

            Response<TagResource> originalTags = tagResource.Get(cancellationToken);
            originalTags.Value.Data.TagValues.Remove(key);
            tagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
            return get(cancellationToken);
        }
    }
}
