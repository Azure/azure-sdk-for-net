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
    // Tag add/remove/set helpers: the new mgmt generator only emits the standard ARM tag operations when the
    // resource's Update (PATCH) returns the resource body. This resource's PATCH is modeled as returning no
    // content (Update -> non-generic ArmOperation), so the generator skips the tag helpers and deliberately
    // does not fall back to PUT. They are hand-authored here to preserve main's GA tag surface. GA's Update is
    // likewise a non-generic ArmOperation, so the no-content modeling cannot be changed in TypeSpec without
    // breaking the Update return-type parity.
    public partial class EventGridDomainResource
    {
        /// <summary> Add a tag to the resource. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridDomainResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
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
                HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
                return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
            }

            EventGridDomainData current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
            EventGridDomainPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags[key] = value;
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Add a tag to the resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<EventGridDomainResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
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
                HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
                return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
            }

            EventGridDomainData current = Get(cancellationToken).Value.Data;
            EventGridDomainPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags[key] = value;
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Remove a tag from the resource. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridDomainResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
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
                HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
                return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
            }

            EventGridDomainData current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
            EventGridDomainPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags.Remove(key);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Remove a tag from the resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<EventGridDomainResource> RemoveTag(string key, CancellationToken cancellationToken = default)
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
                HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
                return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
            }

            EventGridDomainData current = Get(cancellationToken).Value.Data;
            EventGridDomainPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags.Remove(key);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replace the resource tags. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridDomainResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
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
                HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
                return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
            }

            EventGridDomainPatch patch = CreatePatchWithTags(tags);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replace the resource tags. </summary>
        [ForwardsClientCalls]
        public virtual Response<EventGridDomainResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
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
                HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
                return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
            }

            EventGridDomainPatch patch = CreatePatchWithTags(tags);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        private static EventGridDomainPatch CreatePatchWithTags(IDictionary<string, string> tags)
        {
            EventGridDomainPatch patch = new EventGridDomainPatch();
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
