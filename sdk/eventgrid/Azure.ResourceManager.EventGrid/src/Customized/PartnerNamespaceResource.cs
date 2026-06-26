// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    // Tag add/remove/set helpers plus typed private-link resource accessors, hand-authored to preserve main's
    // GA surface. The generator omits the tag helpers because this resource's Update (PATCH) is modeled as
    // returning no content (Update -> non-generic ArmOperation): it only emits the standard ARM tag operations
    // for a content-returning PATCH and deliberately will not fall back to PUT. GA's Update is likewise a
    // non-generic ArmOperation, so the modeling cannot change in TypeSpec without breaking parity.
    public partial class PartnerNamespaceResource
    {
        /// <summary> Gets a collection of PartnerNamespacePrivateLinkResources in the PartnerNamespace. </summary>
        /// <returns> An object representing collection of PartnerNamespacePrivateLinkResources and their operations over a PartnerNamespacePrivateLinkResource. </returns>
        public virtual PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources()
        {
            return GetCachedClient(client => new PartnerNamespacePrivateLinkResourceCollection(client, Id));
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetPartnerNamespacePrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetPartnerNamespacePrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Adds a tag to the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespaceResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
            {
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
                return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
            }

            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags[key] = value;
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Adds a tag to the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespaceResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            if (CanUseTagResource(cancellationToken))
            {
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
                return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
            }

            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags[key] = value;
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Removes a tag from the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespaceResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
            {
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
                return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
            }

            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags.Remove(key);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Removes a tag from the resource. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespaceResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            if (CanUseTagResource(cancellationToken))
            {
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
                return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
            }

            PartnerNamespacePatch patch = CreatePatchWithTags(Data.Tags);
            patch.Tags.Remove(key);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replaces the resource tags. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespaceResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
            {
                await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
                Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
                return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
            }

            PartnerNamespacePatch patch = CreatePatchWithTags(tags);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replaces the resource tags. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespaceResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            if (CanUseTagResource(cancellationToken))
            {
                GetTagResource().Delete(WaitUntil.Completed, cancellationToken);
                Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
                return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
            }

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
