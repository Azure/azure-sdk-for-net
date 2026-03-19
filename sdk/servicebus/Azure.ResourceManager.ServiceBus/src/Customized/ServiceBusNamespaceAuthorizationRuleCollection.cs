// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary>
    /// Workaround for a TypeSpec ARM library bug where @segmentOf produces a camelCase segment
    /// ("authorizationRules") that doesn't match the explicit @segment("AuthorizationRules") on
    /// the resource path parameter. This causes the emitter to misplace the List operation onto
    /// ServiceBusNamespaceResource instead of this collection. We restore GetAll/GetAllAsync and
    /// IEnumerable here to preserve the original API surface.
    /// See: https://github.com/Azure/azure-sdk-for-net/issues/57216
    /// </summary>
    public partial class ServiceBusNamespaceAuthorizationRuleCollection : IEnumerable<ServiceBusNamespaceAuthorizationRuleResource>, IAsyncEnumerable<ServiceBusNamespaceAuthorizationRuleResource>
    {
        private ClientDiagnostics _sbAuthorizationRulesClientDiagnostics;
        private SBAuthorizationRules _sbAuthorizationRulesRestClient;

        private void InitSBAuthorizationRulesClient()
        {
            if (_sbAuthorizationRulesRestClient == null)
            {
                TryGetApiVersion(ServiceBusNamespaceAuthorizationRuleResource.ResourceType, out string apiVersion);
                _sbAuthorizationRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceBus", ServiceBusNamespaceAuthorizationRuleResource.ResourceType.Namespace, Diagnostics);
                _sbAuthorizationRulesRestClient = new SBAuthorizationRules(_sbAuthorizationRulesClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2025-05-01-preview");
            }
        }

        /// <summary>
        /// Gets the authorization rules for a namespace.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceBusNamespaceAuthorizationRuleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceBusNamespaceAuthorizationRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            InitSBAuthorizationRulesClient();
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ServiceBusAuthorizationRuleData, ServiceBusNamespaceAuthorizationRuleResource>(new SBAuthorizationRulesGetAuthorizationRulesAsyncCollectionResultOfT(_sbAuthorizationRulesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context), data => new ServiceBusNamespaceAuthorizationRuleResource(Client, data));
        }

        /// <summary>
        /// Gets the authorization rules for a namespace.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceBusNamespaceAuthorizationRuleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceBusNamespaceAuthorizationRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            InitSBAuthorizationRulesClient();
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ServiceBusAuthorizationRuleData, ServiceBusNamespaceAuthorizationRuleResource>(new SBAuthorizationRulesGetAuthorizationRulesCollectionResultOfT(_sbAuthorizationRulesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context), data => new ServiceBusNamespaceAuthorizationRuleResource(Client, data));
        }

        IEnumerator<ServiceBusNamespaceAuthorizationRuleResource> IEnumerable<ServiceBusNamespaceAuthorizationRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<ServiceBusNamespaceAuthorizationRuleResource> IAsyncEnumerable<ServiceBusNamespaceAuthorizationRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
