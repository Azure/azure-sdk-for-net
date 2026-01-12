// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ManagementGroups
{
    public partial class ManagementGroupResource
    {
        /// <summary>
        /// This operation retrieves the policy set definition in the given management group with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicySetDefinitions_GetAtManagementGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagementGroupPolicySetDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ManagementGroupPolicySetDefinitionResource>> GetManagementGroupPolicySetDefinitionAsync(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return await GetManagementGroupPolicySetDefinitionAsync(policySetDefinitionName, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This operation retrieves the policy set definition in the given management group with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicySetDefinitions_GetAtManagementGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagementGroupPolicySetDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ManagementGroupPolicySetDefinitionResource> GetManagementGroupPolicySetDefinition(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return GetManagementGroupPolicySetDefinition(policySetDefinitionName, default, cancellationToken);
        }
    }
}
