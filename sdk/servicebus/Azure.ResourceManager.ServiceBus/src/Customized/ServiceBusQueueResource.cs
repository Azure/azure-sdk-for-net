// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus
{
    public partial class ServiceBusQueueResource
    {
        /// <summary> Gets a collection of ServiceBusQueueAuthorizationRuleResources. </summary>
        /// <returns> An object representing collection of ServiceBusQueueAuthorizationRuleResources. </returns>
        public virtual ServiceBusQueueAuthorizationRuleCollection GetServiceBusQueueAuthorizationRules() => GetQueues();
        /// <summary> Gets a ServiceBusQueueAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusQueueAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual Response<ServiceBusQueueAuthorizationRuleResource> GetServiceBusQueueAuthorizationRule(string authorizationRuleName, CancellationToken cancellationToken = default) => GetQueue(authorizationRuleName, cancellationToken);
        /// <summary> Gets a ServiceBusQueueAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusQueueAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceBusQueueAuthorizationRuleResource>> GetServiceBusQueueAuthorizationRuleAsync(string authorizationRuleName, CancellationToken cancellationToken = default) => await GetQueueAsync(authorizationRuleName, cancellationToken).ConfigureAwait(false);
    }
}
