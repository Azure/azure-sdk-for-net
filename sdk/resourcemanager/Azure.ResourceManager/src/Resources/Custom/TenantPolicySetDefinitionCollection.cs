// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Resources
{
    public partial class TenantPolicySetDefinitionCollection
    {
        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return await ExistsAsync(policySetDefinitionName, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return Exists(policySetDefinitionName, default, cancellationToken);
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
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TenantPolicySetDefinitionResource>> GetAsync(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return await GetAsync(policySetDefinitionName, default, cancellationToken).ConfigureAwait(false);
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
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TenantPolicySetDefinitionResource> Get(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return Get(policySetDefinitionName, default, cancellationToken);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<TenantPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return await GetIfExistsAsync(policySetDefinitionName, default, cancellationToken ).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<TenantPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, CancellationToken cancellationToken)
        {
            return GetIfExists(policySetDefinitionName, default, cancellationToken);
        }

        /// <summary>
        /// This operation retrieves a list of all the built-in policy set definitions that match the optional given $filter. If $filter='category -eq {value}' is provided, the returned list only includes all built-in policy set definitions whose category match the {value}.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policySetDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicySetDefinitions_ListBuiltIn</description>
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
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atExactScope()', 'policyType -eq {value}' or 'category eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope. If $filter='policyType -eq {value}' is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter='category -eq {value}' is provided, the returned list only includes all policy set definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantPolicySetDefinitionResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<TenantPolicySetDefinitionResource> GetAllAsync(string filter, int? top, CancellationToken cancellationToken)
        {
            return GetAllAsync(filter, default, top, cancellationToken);
        }

        /// <summary>
        /// This operation retrieves a list of all the built-in policy set definitions that match the optional given $filter. If $filter='category -eq {value}' is provided, the returned list only includes all built-in policy set definitions whose category match the {value}.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policySetDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicySetDefinitions_ListBuiltIn</description>
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
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atExactScope()', 'policyType -eq {value}' or 'category eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope. If $filter='policyType -eq {value}' is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter='category -eq {value}' is provided, the returned list only includes all policy set definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantPolicySetDefinitionResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<TenantPolicySetDefinitionResource> GetAll(string filter, int? top, CancellationToken cancellationToken)
        {
            return GetAll(filter, default, top, cancellationToken);
        }
    }
}
