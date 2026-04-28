// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Workaround for generator bug: AddTag/SetTags/RemoveTag helpers emitted by
    // BaseTagMethodProvider call this.UpdateAsync(WaitUntil, <ResourceData>) but
    // the spec uses Azure.ResourceManager.Legacy.CreateOrUpdateAsync<Resource,
    // Request = SeparateBody> with no PATCH operation, so UpdateAsync's body type
    // is a different model (CreateUpdateData / no UpdateAsync on ThroughputSettings),
    // producing CS1503 / CS1061. Tracked at:
    // https://github.com/Azure/azure-sdk-for-net/issues/58747
    //
    // Until the generator is fixed, suppress the broken helpers and reimplement
    // them via the TagResource (Microsoft.Resources/tags) path, which works for
    // any subscription that has tag-resource privileges (the common case).
    // The fallback path (legacy PUT-based tag update) is not supported here -
    // see issue link above for the long-term fix.
    [CodeGenSuppress("AddTagAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AddTag", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SetTagsAsync", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("SetTags", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTagAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTag", typeof(string), typeof(CancellationToken))]
    public partial class GremlinGraphResource
    {
        private const string TagFallbackUnsupportedMessage =
            "AddTag/SetTags/RemoveTag fall back to the resource PUT operation when the subscription does not have tag-resource privileges, but the underlying PUT body type for GremlinGraphResource is a different model from its data type, so the fallback is not supported. See https://github.com/Azure/azure-sdk-for-net/issues/58747.";

        /// <summary> Add a tag to the current resource. </summary>
        public virtual async Task<Response<GremlinGraphResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual Response<GremlinGraphResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            if (CanUseTagResource(cancellationToken: cancellationToken))
            {
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                return Get(cancellationToken: cancellationToken);
            }
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual async Task<Response<GremlinGraphResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<GremlinGraphResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            if (CanUseTagResource(cancellationToken: cancellationToken))
            {
                GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                return Get(cancellationToken: cancellationToken);
            }
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
        }

        /// <summary> Remove a tag by key from the resource. </summary>
        public virtual async Task<Response<GremlinGraphResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
        }

        /// <summary> Remove a tag by key from the resource. </summary>
        public virtual Response<GremlinGraphResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            if (CanUseTagResource(cancellationToken: cancellationToken))
            {
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                return Get(cancellationToken: cancellationToken);
            }
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
        }
    }
}
