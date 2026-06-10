// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (PartnerRegistrationResource lives next to the dynamic-parent resources and is
    // affected by the same generator bug — its Tag methods were not emitted.)
    public partial class PartnerRegistrationResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        public virtual async Task<Response<PartnerRegistrationResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _partnerRegistrationsClientDiagnostics.CreateScope("PartnerRegistrationResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    PartnerRegistrationData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchPartnerRegistrationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual Response<PartnerRegistrationResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _partnerRegistrationsClientDiagnostics.CreateScope("PartnerRegistrationResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                }
                else
                {
                    PartnerRegistrationData current = Get(cancellationToken: cancellationToken).Value.Data;
                    PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchPartnerRegistration(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual async Task<Response<PartnerRegistrationResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _partnerRegistrationsClientDiagnostics.CreateScope("PartnerRegistrationResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
                    patch.Tags.ReplaceWith(tags);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchPartnerRegistrationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<PartnerRegistrationResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _partnerRegistrationsClientDiagnostics.CreateScope("PartnerRegistrationResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                }
                else
                {
                    PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
                    patch.Tags.ReplaceWith(tags);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchPartnerRegistration(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual async Task<Response<PartnerRegistrationResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _partnerRegistrationsClientDiagnostics.CreateScope("PartnerRegistrationResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    PartnerRegistrationData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchPartnerRegistrationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual Response<PartnerRegistrationResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _partnerRegistrationsClientDiagnostics.CreateScope("PartnerRegistrationResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                }
                else
                {
                    PartnerRegistrationData current = Get(cancellationToken: cancellationToken).Value.Data;
                    PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchPartnerRegistration(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<PartnerRegistrationResource>> RefetchPartnerRegistrationAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _partnerRegistrationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            Response<PartnerRegistrationData> response = Response.FromValue(PartnerRegistrationData.FromResponse(result), result);
            return Response.FromValue(new PartnerRegistrationResource(Client, response.Value), response.GetRawResponse());
        }

        private Response<PartnerRegistrationResource> RefetchPartnerRegistration(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _partnerRegistrationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            Response<PartnerRegistrationData> response = Response.FromValue(PartnerRegistrationData.FromResponse(result), result);
            return Response.FromValue(new PartnerRegistrationResource(Client, response.Value), response.GetRawResponse());
        }
    }
}
