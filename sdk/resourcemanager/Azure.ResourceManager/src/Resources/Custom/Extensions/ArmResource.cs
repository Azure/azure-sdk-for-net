// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager
{
    public partial class ArmResource
    {
        /// <summary> Gets an object representing a TagResource along with the instance operations that can be performed on it in the ArmResource. </summary>
        /// <returns> Returns a <see cref="TagResource" /> object. </returns>
        public virtual TagResource GetTagResource()
        {
            return GetCachedClient(client => new TagResource(client, new ResourceIdentifier(Id.ToString() + "/providers/Microsoft.Resources/tags/default")));
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<PolicyAssignmentResource>> GetPolicyAssignmentAsync(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return await GetPolicyAssignmentAsync(policyAssignmentName, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<PolicyAssignmentResource> GetPolicyAssignment(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return GetPolicyAssignment(policyAssignmentName, default, cancellationToken);
        }
    }
}
