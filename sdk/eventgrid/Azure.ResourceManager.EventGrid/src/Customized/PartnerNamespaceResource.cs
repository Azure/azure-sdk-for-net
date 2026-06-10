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
    // (Same root cause as on EventGridDomainResource — see header in
    // Customized/EventGridDomainResource.cs.)
    public partial class PartnerNamespaceResource
    {
        /// <summary> Gets a collection of <see cref="EventGridPartnerNamespacePrivateEndpointConnectionResource"/> in the <see cref="PartnerNamespaceResource"/>. </summary>
        public virtual EventGridPartnerNamespacePrivateEndpointConnectionCollection GetEventGridPartnerNamespacePrivateEndpointConnections()
        {
            return GetCachedClient(client => new EventGridPartnerNamespacePrivateEndpointConnectionCollection(
                client,
                ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName),
                PrivateEndpointConnectionsParentType.PartnerNamespaces,
                Id.Name));
        }

        /// <summary> Get a specific private endpoint connection under a partner namespace. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetEventGridPartnerNamespacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridPartnerNamespacePrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Get a specific private endpoint connection under a partner namespace. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetEventGridPartnerNamespacePrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridPartnerNamespacePrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Gets a collection of <see cref="PartnerNamespacePrivateLinkResource"/> in the <see cref="PartnerNamespaceResource"/>. </summary>
        public virtual PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources()
        {
            return GetCachedClient(client => new PartnerNamespacePrivateLinkResourceCollection(
                client,
                ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName),
                Id.Name));
        }

        /// <summary> Get a specific private link resource under a partner namespace. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetPartnerNamespacePrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Get a specific private link resource under a partner namespace. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetPartnerNamespacePrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual async Task<Response<PartnerNamespaceResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _partnerNamespacesClientDiagnostics.CreateScope("PartnerNamespaceResource.AddTag");
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
                    PartnerNamespaceData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    PartnerNamespacePatch patch = new PartnerNamespacePatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchPartnerNamespaceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual Response<PartnerNamespaceResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _partnerNamespacesClientDiagnostics.CreateScope("PartnerNamespaceResource.AddTag");
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
                    PartnerNamespaceData current = Get(cancellationToken: cancellationToken).Value.Data;
                    PartnerNamespacePatch patch = new PartnerNamespacePatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchPartnerNamespace(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual async Task<Response<PartnerNamespaceResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _partnerNamespacesClientDiagnostics.CreateScope("PartnerNamespaceResource.SetTags");
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
                    PartnerNamespacePatch patch = new PartnerNamespacePatch();
                    patch.Tags.ReplaceWith(tags);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchPartnerNamespaceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<PartnerNamespaceResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _partnerNamespacesClientDiagnostics.CreateScope("PartnerNamespaceResource.SetTags");
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
                    PartnerNamespacePatch patch = new PartnerNamespacePatch();
                    patch.Tags.ReplaceWith(tags);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchPartnerNamespace(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual async Task<Response<PartnerNamespaceResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _partnerNamespacesClientDiagnostics.CreateScope("PartnerNamespaceResource.RemoveTag");
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
                    PartnerNamespaceData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    PartnerNamespacePatch patch = new PartnerNamespacePatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchPartnerNamespaceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual Response<PartnerNamespaceResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _partnerNamespacesClientDiagnostics.CreateScope("PartnerNamespaceResource.RemoveTag");
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
                    PartnerNamespaceData current = Get(cancellationToken: cancellationToken).Value.Data;
                    PartnerNamespacePatch patch = new PartnerNamespacePatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchPartnerNamespace(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<PartnerNamespaceResource>> RefetchPartnerNamespaceAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
            return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
        }

        private Response<PartnerNamespaceResource> RefetchPartnerNamespace(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _partnerNamespacesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            Response<PartnerNamespaceData> response = Response.FromValue(PartnerNamespaceData.FromResponse(result), result);
            return Response.FromValue(new PartnerNamespaceResource(Client, response.Value), response.GetRawResponse());
        }
    }
}
