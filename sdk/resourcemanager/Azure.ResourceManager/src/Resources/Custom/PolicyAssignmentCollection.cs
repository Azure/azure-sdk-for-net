// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups;

namespace Azure.ResourceManager.Resources
{
    public partial class PolicyAssignmentCollection
    {
        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return await ExistsAsync(policyAssignmentName, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return Exists(policyAssignmentName, default, cancellationToken);
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
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PolicyAssignmentResource>> GetAsync(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return await GetAsync(policyAssignmentName, default, cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PolicyAssignmentResource> Get(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return Get(policyAssignmentName, default, cancellationToken);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<PolicyAssignmentResource>> GetIfExistsAsync(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return await GetIfExistsAsync(policyAssignmentName, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<PolicyAssignmentResource> GetIfExists(string policyAssignmentName, CancellationToken cancellationToken)
        {
            return GetIfExists(policyAssignmentName, default, cancellationToken);
        }

        /// <summary>
        /// This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_ListForResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_ListForResource</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_ListForManagementGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_List</description>
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
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyAssignmentResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PolicyAssignmentResource> GetAllAsync(string filter, int? top, CancellationToken cancellationToken)
        {
            return GetAllAsync(filter, default, top, cancellationToken);
        }

        /// <summary>
        /// This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_ListForResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_ListForResource</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_ListForManagementGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PolicyAssignmentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyAssignments_List</description>
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
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyAssignmentResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PolicyAssignmentResource> GetAll(string filter, int? top, CancellationToken cancellationToken)
        {
            return GetAll(filter, default, top, cancellationToken);
        }
    }
}
