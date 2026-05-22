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
    public partial class EventGridTopicResource
    {
        /// <summary> Gets a collection of <see cref="TopicNetworkSecurityPerimeterConfigurationResource"/> in the <see cref="EventGridTopicResource"/>. </summary>
        public virtual TopicNetworkSecurityPerimeterConfigurationCollection GetTopicNetworkSecurityPerimeterConfigurations()
        {
            return GetCachedClient(client => new TopicNetworkSecurityPerimeterConfigurationCollection(client, Id));
        }

        /// <summary> Get a single network security perimeter configuration for an event-grid topic by perimeter GUID and association name. </summary>
        /// <param name="perimeterGuid"> The unique identifier of the Network Security Perimeter resource. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetTopicNetworkSecurityPerimeterConfigurationAsync(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            return GetTopicNetworkSecurityPerimeterConfigurations().GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Get a single network security perimeter configuration for an event-grid topic by perimeter GUID and association name. </summary>
        /// <param name="perimeterGuid"> The unique identifier of the Network Security Perimeter resource. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> GetTopicNetworkSecurityPerimeterConfiguration(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            return GetTopicNetworkSecurityPerimeterConfigurations().Get(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Gets a collection of <see cref="EventGridTopicPrivateEndpointConnectionResource"/> in the <see cref="EventGridTopicResource"/>. </summary>
        public virtual EventGridTopicPrivateEndpointConnectionCollection GetEventGridTopicPrivateEndpointConnections()
        {
            return GetCachedClient(client => new EventGridTopicPrivateEndpointConnectionCollection(
                client,
                ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName),
                PrivateEndpointConnectionsParentType.Topics,
                Id.Name));
        }

        /// <summary> Get a specific private endpoint connection under a topic. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<EventGridTopicPrivateEndpointConnectionResource>> GetEventGridTopicPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Get a specific private endpoint connection under a topic. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<EventGridTopicPrivateEndpointConnectionResource> GetEventGridTopicPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Gets a collection of <see cref="EventGridTopicPrivateLinkResource"/> in the <see cref="EventGridTopicResource"/>. </summary>
        public virtual EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources()
        {
            return GetCachedClient(client => new EventGridTopicPrivateLinkResourceCollection(
                client,
                ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName),
                Id.Name));
        }

        /// <summary> Get a specific private link resource under a topic. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<EventGridTopicPrivateLinkResource>> GetEventGridTopicPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Get a specific private link resource under a topic. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<EventGridTopicPrivateLinkResource> GetEventGridTopicPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual async Task<Response<EventGridTopicResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _topicsClientDiagnostics.CreateScope("EventGridTopicResource.AddTag");
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
                    EventGridTopicData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    EventGridTopicPatch patch = new EventGridTopicPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchTopicResourceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        public virtual Response<EventGridTopicResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            using DiagnosticScope scope = _topicsClientDiagnostics.CreateScope("EventGridTopicResource.AddTag");
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
                    EventGridTopicData current = Get(cancellationToken: cancellationToken).Value.Data;
                    EventGridTopicPatch patch = new EventGridTopicPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchTopicResource(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual async Task<Response<EventGridTopicResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _topicsClientDiagnostics.CreateScope("EventGridTopicResource.SetTags");
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
                    EventGridTopicPatch patch = new EventGridTopicPatch();
                    patch.Tags.ReplaceWith(tags);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchTopicResourceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        public virtual Response<EventGridTopicResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            using DiagnosticScope scope = _topicsClientDiagnostics.CreateScope("EventGridTopicResource.SetTags");
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
                    EventGridTopicPatch patch = new EventGridTopicPatch();
                    patch.Tags.ReplaceWith(tags);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchTopicResource(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual async Task<Response<EventGridTopicResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _topicsClientDiagnostics.CreateScope("EventGridTopicResource.RemoveTag");
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
                    EventGridTopicData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    EventGridTopicPatch patch = new EventGridTopicPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                return await RefetchTopicResourceAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        public virtual Response<EventGridTopicResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            using DiagnosticScope scope = _topicsClientDiagnostics.CreateScope("EventGridTopicResource.RemoveTag");
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
                    EventGridTopicData current = Get(cancellationToken: cancellationToken).Value.Data;
                    EventGridTopicPatch patch = new EventGridTopicPatch();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                }
                return RefetchTopicResource(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<EventGridTopicResource>> RefetchTopicResourceAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _topicsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            Response<EventGridTopicData> response = Response.FromValue(EventGridTopicData.FromResponse(result), result);
            return Response.FromValue(new EventGridTopicResource(Client, response.Value), response.GetRawResponse());
        }

        private Response<EventGridTopicResource> RefetchTopicResource(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            HttpMessage message = _topicsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            Response result = Pipeline.ProcessMessage(message, context);
            Response<EventGridTopicData> response = Response.FromValue(EventGridTopicData.FromResponse(result), result);
            return Response.FromValue(new EventGridTopicResource(Client, response.Value), response.GetRawResponse());
        }
    }
}
