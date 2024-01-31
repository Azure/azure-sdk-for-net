// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// A Class representing a SecurityConnector along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SecurityConnectorResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSecurityConnectorResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetSecurityConnector method.
    /// </summary>
    public partial class SecurityConnectorResource : ArmResource
    {
        /// <summary> Gets a collection of SecurityConnectorGovernanceRuleResources in the SecurityConnector. </summary>
        /// <returns> An object representing collection of SecurityConnectorGovernanceRuleResources and their operations over a SecurityConnectorGovernanceRuleResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public virtual SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules()
        {
            return GetCachedClient(Client => new SecurityConnectorGovernanceRuleCollection(Client, Id));
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public virtual async Task<Response<SecurityConnectorGovernanceRuleResource>> GetSecurityConnectorGovernanceRuleAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityConnectorGovernanceRules().GetAsync(ruleId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public virtual Response<SecurityConnectorGovernanceRuleResource> GetSecurityConnectorGovernanceRule(string ruleId, CancellationToken cancellationToken = default)
        {
            return GetSecurityConnectorGovernanceRules().Get(ruleId, cancellationToken);
        }
    }
}
