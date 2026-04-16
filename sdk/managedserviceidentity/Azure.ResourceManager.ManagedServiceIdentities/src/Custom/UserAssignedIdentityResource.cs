// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagedServiceIdentities.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.ResourceManager.ManagedServiceIdentities
{
    // Backward-compat stubs: GetAssociatedResources/GetAssociatedResourcesAsync existed in
    // pre-migration baseline but rely on a preview-only listAssociatedResources operation.
    //
    // AddTag/SetTags/RemoveTag (sync+async): overridden to fix a generator bug where the
    // else-branch (patch path) uses the internal parameterless constructor of
    // UserAssignedIdentityPatch which leaves Tags uninitialized (null). The fix is to use
    // new UserAssignedIdentityPatch(current.Location) which initializes Tags properly.

    [CodeGenSuppress("AddTagAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AddTag", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SetTagsAsync", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("SetTags", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTagAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTag", typeof(string), typeof(CancellationToken))]
    public partial class UserAssignedIdentityResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        public virtual async Task<Response<UserAssignedIdentityResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _userAssignedIdentitiesClientDiagnostics.CreateScope("UserAssignedIdentityResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _userAssignedIdentitiesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<UserAssignedIdentityData> response = Response.FromValue(UserAssignedIdentityData.FromResponse(result), result);
                    return Response.FromValue(new UserAssignedIdentityResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    UserAssignedIdentityData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    UserAssignedIdentityPatch patch = new UserAssignedIdentityPatch(current.Location);
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                        patch.Tags.Add(tag);
                    patch.Tags[key] = value;
                    Response<UserAssignedIdentityResource> result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual Response<UserAssignedIdentityResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _userAssignedIdentitiesClientDiagnostics.CreateScope("UserAssignedIdentityResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _userAssignedIdentitiesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<UserAssignedIdentityData> response = Response.FromValue(UserAssignedIdentityData.FromResponse(result), result);
                    return Response.FromValue(new UserAssignedIdentityResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    UserAssignedIdentityData current = Get(cancellationToken: cancellationToken).Value.Data;
                    UserAssignedIdentityPatch patch = new UserAssignedIdentityPatch(current.Location);
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                        patch.Tags.Add(tag);
                    patch.Tags[key] = value;
                    Response<UserAssignedIdentityResource> result = Update(patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual async Task<Response<UserAssignedIdentityResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _userAssignedIdentitiesClientDiagnostics.CreateScope("UserAssignedIdentityResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _userAssignedIdentitiesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<UserAssignedIdentityData> response = Response.FromValue(UserAssignedIdentityData.FromResponse(result), result);
                    return Response.FromValue(new UserAssignedIdentityResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    UserAssignedIdentityData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    UserAssignedIdentityPatch patch = new UserAssignedIdentityPatch(current.Location);
                    patch.Tags.ReplaceWith(tags);
                    Response<UserAssignedIdentityResource> result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<UserAssignedIdentityResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _userAssignedIdentitiesClientDiagnostics.CreateScope("UserAssignedIdentityResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken);
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _userAssignedIdentitiesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<UserAssignedIdentityData> response = Response.FromValue(UserAssignedIdentityData.FromResponse(result), result);
                    return Response.FromValue(new UserAssignedIdentityResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    UserAssignedIdentityData current = Get(cancellationToken: cancellationToken).Value.Data;
                    UserAssignedIdentityPatch patch = new UserAssignedIdentityPatch(current.Location);
                    patch.Tags.ReplaceWith(tags);
                    Response<UserAssignedIdentityResource> result = Update(patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual async Task<Response<UserAssignedIdentityResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _userAssignedIdentitiesClientDiagnostics.CreateScope("UserAssignedIdentityResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _userAssignedIdentitiesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<UserAssignedIdentityData> response = Response.FromValue(UserAssignedIdentityData.FromResponse(result), result);
                    return Response.FromValue(new UserAssignedIdentityResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    UserAssignedIdentityData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    UserAssignedIdentityPatch patch = new UserAssignedIdentityPatch(current.Location);
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                        patch.Tags.Add(tag);
                    patch.Tags.Remove(key);
                    Response<UserAssignedIdentityResource> result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual Response<UserAssignedIdentityResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _userAssignedIdentitiesClientDiagnostics.CreateScope("UserAssignedIdentityResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _userAssignedIdentitiesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<UserAssignedIdentityData> response = Response.FromValue(UserAssignedIdentityData.FromResponse(result), result);
                    return Response.FromValue(new UserAssignedIdentityResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    UserAssignedIdentityData current = Get(cancellationToken: cancellationToken).Value.Data;
                    UserAssignedIdentityPatch patch = new UserAssignedIdentityPatch(current.Location);
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                        patch.Tags.Add(tag);
                    patch.Tags.Remove(key);
                    Response<UserAssignedIdentityResource> result = Update(patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResources(
            string filter = null,
            string orderby = null,
            int? top = default,
            int? skip = default,
            string skiptoken = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API.");
        }

        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResourcesAsync(
            string filter = null,
            string orderby = null,
            int? top = default,
            int? skip = default,
            string skiptoken = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API.");
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
