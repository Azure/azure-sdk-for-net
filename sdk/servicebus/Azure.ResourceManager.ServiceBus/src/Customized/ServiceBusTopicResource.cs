// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus
{
    public partial class ServiceBusTopicResource
    {
        /// <summary> Gets a collection of ServiceBusTopicAuthorizationRuleResources. </summary>
        /// <returns> An object representing collection of ServiceBusTopicAuthorizationRuleResources. </returns>
        public virtual ServiceBusTopicAuthorizationRuleCollection GetServiceBusTopicAuthorizationRules() => GetTopics();
        /// <summary> Gets a ServiceBusTopicAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusTopicAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual Response<ServiceBusTopicAuthorizationRuleResource> GetServiceBusTopicAuthorizationRule(string authorizationRuleName, CancellationToken cancellationToken = default) => GetTopic(authorizationRuleName, cancellationToken);
        /// <summary> Gets a ServiceBusTopicAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusTopicAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceBusTopicAuthorizationRuleResource>> GetServiceBusTopicAuthorizationRuleAsync(string authorizationRuleName, CancellationToken cancellationToken = default) => await GetTopicAsync(authorizationRuleName, cancellationToken).ConfigureAwait(false);
    }
}
