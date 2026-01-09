// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Resources
{
    public partial class TenantPolicySetDefinitionResource
    {
        /// <summary>
        /// This operation retrieves the built-in policy set definition with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicySetDefinitions_GetBuiltIn</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TenantPolicySetDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TenantPolicySetDefinitionResource>> GetAsync(CancellationToken cancellationToken)
        {
            return await GetAsync(default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This operation retrieves the built-in policy set definition with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicySetDefinitions_GetBuiltIn</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TenantPolicySetDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TenantPolicySetDefinitionResource> Get(CancellationToken cancellationToken)
        {
            return Get(default, cancellationToken);
        }
    }
}
