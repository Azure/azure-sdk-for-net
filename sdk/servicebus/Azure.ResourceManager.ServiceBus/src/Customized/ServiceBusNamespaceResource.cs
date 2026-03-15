// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ServiceBus.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceBus
{
    [CodeGenSuppress("GetPrivateLinkResourcesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetPrivateLinkResources", typeof(CancellationToken))]
    public partial class ServiceBusNamespaceResource
    {
        /// <summary> Gets a collection of ServiceBusNamespaceAuthorizationRuleResources. </summary>
        /// <returns> An object representing collection of ServiceBusNamespaceAuthorizationRuleResources. </returns>
        public virtual ServiceBusNamespaceAuthorizationRuleCollection GetServiceBusNamespaceAuthorizationRules() => GetNamespaces();
        /// <summary> Gets a ServiceBusNamespaceAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusNamespaceAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual Response<ServiceBusNamespaceAuthorizationRuleResource> GetServiceBusNamespaceAuthorizationRule(string authorizationRuleName, CancellationToken cancellationToken = default) => GetNamespace(authorizationRuleName, cancellationToken);
        /// <summary> Gets a ServiceBusNamespaceAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusNamespaceAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceBusNamespaceAuthorizationRuleResource>> GetServiceBusNamespaceAuthorizationRuleAsync(string authorizationRuleName, CancellationToken cancellationToken = default) => await GetNamespaceAsync(authorizationRuleName, cancellationToken).ConfigureAwait(false);
        /// <summary> Gets a collection of ServiceBusPrivateEndpointConnectionResources. </summary>
        /// <returns> An object representing collection of ServiceBusPrivateEndpointConnectionResources. </returns>
        public virtual ServiceBusPrivateEndpointConnectionCollection GetServiceBusPrivateEndpointConnections() => GetPrivateEndpointConnections();
        /// <summary> Gets a ServiceBusPrivateEndpointConnectionResource. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusPrivateEndpointConnectionResource. </returns>
        [ForwardsClientCalls]
        public virtual Response<ServiceBusPrivateEndpointConnectionResource> GetServiceBusPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default) => GetPrivateEndpointConnection(privateEndpointConnectionName, cancellationToken);
        /// <summary> Gets a ServiceBusPrivateEndpointConnectionResource. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusPrivateEndpointConnectionResource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceBusPrivateEndpointConnectionResource>> GetServiceBusPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default) => await GetPrivateEndpointConnectionAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
        /// <summary> Update the namespace. </summary>
        /// <param name="patch"> Parameters supplied to the update namespace operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated ServiceBusNamespaceResource. </returns>
        public virtual Response<ServiceBusNamespaceResource> Update(ServiceBusNamespacePatch patch, CancellationToken cancellationToken = default)
        {
            var operation = Update(Azure.WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
        /// <summary> Update the namespace. </summary>
        /// <param name="patch"> Parameters supplied to the update namespace operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated ServiceBusNamespaceResource. </returns>
        public virtual async Task<Response<ServiceBusNamespaceResource>> UpdateAsync(ServiceBusNamespacePatch patch, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(Azure.WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Gets lists of resources that supports Privatelinks. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceBusPrivateLinkResource"/>. </returns>
        public virtual AsyncPageable<ServiceBusPrivateLinkResource> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            return new PrivateLinkResourceAsyncPageable(this, cancellationToken);
        }

        /// <summary> Gets lists of resources that supports Privatelinks. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceBusPrivateLinkResource"/>. </returns>
        public virtual Pageable<ServiceBusPrivateLinkResource> GetPrivateLinkResources(CancellationToken cancellationToken = default)
        {
            return new PrivateLinkResourcePageable(this, cancellationToken);
        }

        private sealed class PrivateLinkResourcePageable : Pageable<ServiceBusPrivateLinkResource>
        {
            private readonly ServiceBusNamespaceResource _parent;
            private readonly CancellationToken _cancellationToken;

            internal PrivateLinkResourcePageable(ServiceBusNamespaceResource parent, CancellationToken cancellationToken)
            {
                _parent = parent;
                _cancellationToken = cancellationToken;
            }

            public override IEnumerable<Page<ServiceBusPrivateLinkResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                using DiagnosticScope scope = _parent._privateLinkResourcesClientDiagnostics.CreateScope("ServiceBusNamespaceResource.GetPrivateLinkResources");
                scope.Start();
                Response result;
                PrivateLinkResourcesListResult listResult;
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = _cancellationToken };
                    HttpMessage message = _parent._privateLinkResourcesRestClient.CreateGetPrivateLinkResourcesRequest(
                        Guid.Parse(_parent.Id.SubscriptionId), _parent.Id.ResourceGroupName, _parent.Id.Name, context);
                    result = _parent.Pipeline.ProcessMessage(message, context);
                    listResult = PrivateLinkResourcesListResult.FromResponse(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
                yield return Page<ServiceBusPrivateLinkResource>.FromValues(listResult.Value.ToArray(), null, result);
            }
        }

        private sealed class PrivateLinkResourceAsyncPageable : AsyncPageable<ServiceBusPrivateLinkResource>
        {
            private readonly ServiceBusNamespaceResource _parent;
            private readonly CancellationToken _cancellationToken;

            internal PrivateLinkResourceAsyncPageable(ServiceBusNamespaceResource parent, CancellationToken cancellationToken)
            {
                _parent = parent;
                _cancellationToken = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<ServiceBusPrivateLinkResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                using DiagnosticScope scope = _parent._privateLinkResourcesClientDiagnostics.CreateScope("ServiceBusNamespaceResource.GetPrivateLinkResources");
                scope.Start();
                Response result;
                PrivateLinkResourcesListResult listResult;
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = _cancellationToken };
                    HttpMessage message = _parent._privateLinkResourcesRestClient.CreateGetPrivateLinkResourcesRequest(
                        Guid.Parse(_parent.Id.SubscriptionId), _parent.Id.ResourceGroupName, _parent.Id.Name, context);
                    result = await _parent.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    listResult = PrivateLinkResourcesListResult.FromResponse(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
                yield return Page<ServiceBusPrivateLinkResource>.FromValues(listResult.Value.ToArray(), null, result);
            }
        }
    }
}
