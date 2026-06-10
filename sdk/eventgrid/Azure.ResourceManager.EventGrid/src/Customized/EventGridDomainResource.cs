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
    // (Mgmt CodeGen dynamic-parent expansion: PR #58139 split child Resource/Collection
    // classes per parent but did not finish wiring per-parent operation routing or
    // restore the per-parent navigation/tag surface on the dynamic-parent parents
    // (Domain/Topic/PartnerNamespace). Provide the back-compat surface here without
    // touching the spec.)
    public partial class EventGridDomainResource
    {
        /// <summary> Gets a collection of <see cref="DomainNetworkSecurityPerimeterConfigurationResource"/> in the <see cref="EventGridDomainResource"/>. </summary>
        public virtual DomainNetworkSecurityPerimeterConfigurationCollection GetDomainNetworkSecurityPerimeterConfigurations()
        {
            return GetCachedClient(client => new DomainNetworkSecurityPerimeterConfigurationCollection(client, Id));
        }

        /// <summary> Get a single network security perimeter configuration for an event-grid domain by perimeter GUID and association name. </summary>
        /// <param name="perimeterGuid"> The unique identifier of the Network Security Perimeter resource. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<DomainNetworkSecurityPerimeterConfigurationResource>> GetDomainNetworkSecurityPerimeterConfigurationAsync(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            return GetDomainNetworkSecurityPerimeterConfigurations().GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Get a single network security perimeter configuration for an event-grid domain by perimeter GUID and association name. </summary>
        /// <param name="perimeterGuid"> The unique identifier of the Network Security Perimeter resource. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<DomainNetworkSecurityPerimeterConfigurationResource> GetDomainNetworkSecurityPerimeterConfiguration(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            return GetDomainNetworkSecurityPerimeterConfigurations().Get(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Gets a collection of <see cref="EventGridDomainPrivateEndpointConnectionResource"/> in the <see cref="EventGridDomainResource"/>. </summary>
        public virtual EventGridDomainPrivateEndpointConnectionCollection GetEventGridDomainPrivateEndpointConnections()
        {
            return GetCachedClient(client => new EventGridDomainPrivateEndpointConnectionCollection(
                client,
                ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName),
                PrivateEndpointConnectionsParentType.Domains,
                Id.Name));
        }

        /// <summary> Get a specific private endpoint connection under a domain. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<EventGridDomainPrivateEndpointConnectionResource>> GetEventGridDomainPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Get a specific private endpoint connection under a domain. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<EventGridDomainPrivateEndpointConnectionResource> GetEventGridDomainPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Gets a collection of <see cref="EventGridDomainPrivateLinkResource"/> in the <see cref="EventGridDomainResource"/>. </summary>
        public virtual EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources()
        {
            return GetCachedClient(client => new EventGridDomainPrivateLinkResourceCollection(
                client,
                ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName),
                Id.Name));
        }

        /// <summary> Get a specific private link resource under a domain. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<EventGridDomainPrivateLinkResource>> GetEventGridDomainPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Get a specific private link resource under a domain. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<EventGridDomainPrivateLinkResource> GetEventGridDomainPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EventGridDomainResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _domainsClientDiagnostics.CreateScope("EventGridDomainResource.AddTag");
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
                    EventGridDomainData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    EventGridDomainPatch patch = new EventGridDomainPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchDomainResourceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventGridDomainResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _domainsClientDiagnostics.CreateScope("EventGridDomainResource.AddTag");
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
                    EventGridDomainData current = Get(cancellationToken: cancellationToken).Value.Data;
                    EventGridDomainPatch patch = new EventGridDomainPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchDomainResource(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EventGridDomainResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _domainsClientDiagnostics.CreateScope("EventGridDomainResource.SetTags");
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
                    EventGridDomainPatch patch = new EventGridDomainPatch();
                    patch.Tags.ReplaceWith(tags);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchDomainResourceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventGridDomainResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _domainsClientDiagnostics.CreateScope("EventGridDomainResource.SetTags");
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
                    EventGridDomainPatch patch = new EventGridDomainPatch();
                    patch.Tags.ReplaceWith(tags);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchDomainResource(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EventGridDomainResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _domainsClientDiagnostics.CreateScope("EventGridDomainResource.RemoveTag");
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
                    EventGridDomainData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    EventGridDomainPatch patch = new EventGridDomainPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchDomainResourceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventGridDomainResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _domainsClientDiagnostics.CreateScope("EventGridDomainResource.RemoveTag");
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
                    EventGridDomainData current = Get(cancellationToken: cancellationToken).Value.Data;
                    EventGridDomainPatch patch = new EventGridDomainPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchDomainResource(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<EventGridDomainResource>> RefetchDomainResourceAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
            return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
        }

        private Response<EventGridDomainResource> RefetchDomainResource(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _domainsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            Response<EventGridDomainData> response = Response.FromValue(EventGridDomainData.FromResponse(result), result);
            return Response.FromValue(new EventGridDomainResource(Client, response.Value), response.GetRawResponse());
        }
    }
}
