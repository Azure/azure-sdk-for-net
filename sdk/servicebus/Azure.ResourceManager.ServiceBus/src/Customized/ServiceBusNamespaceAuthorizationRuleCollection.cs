// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.ServiceBus.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceBus
{
    [CodeGenType("NamespaceCollection")]
    public partial class ServiceBusNamespaceAuthorizationRuleCollection : IEnumerable<ServiceBusNamespaceAuthorizationRuleResource>, IAsyncEnumerable<ServiceBusNamespaceAuthorizationRuleResource>
    {
        /// <summary> Gets all authorization rules for a namespace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceBusNamespaceAuthorizationRuleResource"/>. </returns>
        public virtual AsyncPageable<ServiceBusNamespaceAuthorizationRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<ServiceBusAuthorizationRuleData, ServiceBusNamespaceAuthorizationRuleResource>(
                new NamespacesGetAuthorizationRulesAsyncCollectionResultOfT(_namespacesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context),
                data => new ServiceBusNamespaceAuthorizationRuleResource(Client, data));
        }

        /// <summary> Gets all authorization rules for a namespace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceBusNamespaceAuthorizationRuleResource"/>. </returns>
        public virtual Pageable<ServiceBusNamespaceAuthorizationRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<ServiceBusAuthorizationRuleData, ServiceBusNamespaceAuthorizationRuleResource>(
                new NamespacesGetAuthorizationRulesCollectionResultOfT(_namespacesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context),
                data => new ServiceBusNamespaceAuthorizationRuleResource(Client, data));
        }

        IEnumerator<ServiceBusNamespaceAuthorizationRuleResource> IEnumerable<ServiceBusNamespaceAuthorizationRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServiceBusNamespaceAuthorizationRuleResource> IAsyncEnumerable<ServiceBusNamespaceAuthorizationRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
