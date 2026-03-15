// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus
{
    public partial class ServiceBusDisasterRecoveryResource
    {
        /// <summary> Gets a collection of ServiceBusDisasterRecoveryAuthorizationRuleResources. </summary>
        /// <returns> An object representing collection of ServiceBusDisasterRecoveryAuthorizationRuleResources. </returns>
        public virtual ServiceBusDisasterRecoveryAuthorizationRuleCollection GetServiceBusDisasterRecoveryAuthorizationRules() => GetDisasterRecoveryConfigs();
        /// <summary> Gets a ServiceBusDisasterRecoveryAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusDisasterRecoveryAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual Response<ServiceBusDisasterRecoveryAuthorizationRuleResource> GetServiceBusDisasterRecoveryAuthorizationRule(string authorizationRuleName, CancellationToken cancellationToken = default) => GetDisasterRecoveryConfig(authorizationRuleName, cancellationToken);
        /// <summary> Gets a ServiceBusDisasterRecoveryAuthorizationRuleResource. </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A response with the ServiceBusDisasterRecoveryAuthorizationRuleResource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceBusDisasterRecoveryAuthorizationRuleResource>> GetServiceBusDisasterRecoveryAuthorizationRuleAsync(string authorizationRuleName, CancellationToken cancellationToken = default) => await GetDisasterRecoveryConfigAsync(authorizationRuleName, cancellationToken).ConfigureAwait(false);
    }
}
