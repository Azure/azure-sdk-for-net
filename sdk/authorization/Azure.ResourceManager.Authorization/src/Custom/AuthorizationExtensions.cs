// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Authorization.Mocking;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Authorization
{
    public static partial class AuthorizationExtensions
    {
        // TypeSpec places the variable-resource permissions operation on ArmClient and generates the singular name.
        // These legacy extensions restore the shipped ResourceGroupResource methods and forward through their mockable surface.

        /// <summary>
        /// Gets all permissions the caller has for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzurePermissionsForResource_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-04-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAuthorizationResourceGroupResource.GetAzurePermissionsForResources(string,string,string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="parentResourcePath"> The parent resource identity. </param>
        /// <param name="resourceType"> The resource type of the resource. </param>
        /// <param name="resourceName"> The name of the resource to get the permissions for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <returns> An async collection of <see cref="RoleDefinitionPermission"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAzurePermissionsForResource instead.")]
        public static AsyncPageable<RoleDefinitionPermission> GetAzurePermissionsForResourcesAsync(this ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableAuthorizationResourceGroupResource(resourceGroupResource).GetAzurePermissionsForResourcesAsync(resourceProviderNamespace, parentResourcePath, resourceType, resourceName, cancellationToken);
        }

        /// <summary>
        /// Gets all permissions the caller has for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzurePermissionsForResource_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-04-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAuthorizationResourceGroupResource.GetAzurePermissionsForResources(string,string,string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="parentResourcePath"> The parent resource identity. </param>
        /// <param name="resourceType"> The resource type of the resource. </param>
        /// <param name="resourceName"> The name of the resource to get the permissions for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <returns> A collection of <see cref="RoleDefinitionPermission"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAzurePermissionsForResource instead.")]
        public static Pageable<RoleDefinitionPermission> GetAzurePermissionsForResources(this ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableAuthorizationResourceGroupResource(resourceGroupResource).GetAzurePermissionsForResources(resourceProviderNamespace, parentResourcePath, resourceType, resourceName, cancellationToken);
        }

        // AutoRest exposed roleDefinitionId as ResourceIdentifier while TypeSpec generates the service's string name.
        // These hidden overloads restore the shipped signatures and forward to the generated string methods.

        /// <inheritdoc cref="GetAuthorizationRoleDefinition(ArmClient, ResourceIdentifier, string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinition(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        [ForwardsClientCalls]
        public static Response<AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this ArmClient client, ResourceIdentifier scope, ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return GetMockableAuthorizationArmClient(client).GetAuthorizationRoleDefinition(scope, roleDefinitionId, cancellationToken);
        }

        /// <inheritdoc cref="GetAuthorizationRoleDefinitionAsync(ArmClient, ResourceIdentifier, string, CancellationToken)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinitionAsync(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        [ForwardsClientCalls]
        public static async Task<Response<AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this ArmClient client, ResourceIdentifier scope, ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await GetMockableAuthorizationArmClient(client).GetAuthorizationRoleDefinitionAsync(scope, roleDefinitionId, cancellationToken).ConfigureAwait(false);
        }

        // The management generator omits generic ArmResource extensions.
        // This block restores the shipped generic ArmResource extension surface through the matching mockable type.

        private static MockableAuthorizationArmResource GetMockableAuthorizationArmResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableAuthorizationArmResource(client, resource.Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetAuthorizationRoleDefinitions()"/>
        public static AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetAuthorizationRoleDefinitions();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetAuthorizationRoleDefinition(ResourceIdentifier, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this ArmResource armResource, ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetAuthorizationRoleDefinition(roleDefinitionId, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetAuthorizationRoleDefinitionAsync(ResourceIdentifier, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this ArmResource armResource, ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetAuthorizationRoleDefinitionAsync(roleDefinitionId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetDenyAssignments()"/>
        public static DenyAssignmentCollection GetDenyAssignments(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetDenyAssignments();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetDenyAssignment(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<DenyAssignmentResource> GetDenyAssignment(this ArmResource armResource, string denyAssignmentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetDenyAssignment(denyAssignmentId, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetDenyAssignmentAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<DenyAssignmentResource>> GetDenyAssignmentAsync(this ArmResource armResource, string denyAssignmentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetDenyAssignmentAsync(denyAssignmentId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignments()"/>
        public static RoleAssignmentCollection GetRoleAssignments(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignments();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignment(string, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleAssignmentResource> GetRoleAssignment(this ArmResource armResource, string roleAssignmentName, string tenantId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignment(roleAssignmentName, tenantId, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentAsync(string, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleAssignmentResource>> GetRoleAssignmentAsync(this ArmResource armResource, string roleAssignmentName, string tenantId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentAsync(roleAssignmentName, tenantId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentSchedules()"/>
        public static RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentSchedules();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentSchedule(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(this ArmResource armResource, string roleAssignmentScheduleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentSchedule(roleAssignmentScheduleName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(this ArmResource armResource, string roleAssignmentScheduleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleAsync(roleAssignmentScheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleInstances()"/>
        public static RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleInstances();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleInstance(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(this ArmResource armResource, string roleAssignmentScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleInstance(roleAssignmentScheduleInstanceName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleInstanceAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(this ArmResource armResource, string roleAssignmentScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleInstanceAsync(roleAssignmentScheduleInstanceName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleRequests()"/>
        public static RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleRequests();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleRequest(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(this ArmResource armResource, string roleAssignmentScheduleRequestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleRequest(roleAssignmentScheduleRequestName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleAssignmentScheduleRequestAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(this ArmResource armResource, string roleAssignmentScheduleRequestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleAssignmentScheduleRequestAsync(roleAssignmentScheduleRequestName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilitySchedules()"/>
        public static RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleEligibilitySchedules();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilitySchedule(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(this ArmResource armResource, string roleEligibilityScheduleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleEligibilitySchedule(roleEligibilityScheduleName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(this ArmResource armResource, string roleEligibilityScheduleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleAsync(roleEligibilityScheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleInstances()"/>
        public static RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleInstances();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleInstance(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(this ArmResource armResource, string roleEligibilityScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleInstance(roleEligibilityScheduleInstanceName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleInstanceAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(this ArmResource armResource, string roleEligibilityScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleInstanceAsync(roleEligibilityScheduleInstanceName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleRequests()"/>
        public static RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleRequests();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleRequest(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(this ArmResource armResource, string roleEligibilityScheduleRequestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleRequest(roleEligibilityScheduleRequestName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleEligibilityScheduleRequestAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(this ArmResource armResource, string roleEligibilityScheduleRequestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleEligibilityScheduleRequestAsync(roleEligibilityScheduleRequestName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleManagementPolicies()"/>
        public static RoleManagementPolicyCollection GetRoleManagementPolicies(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleManagementPolicies();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleManagementPolicy(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleManagementPolicyResource> GetRoleManagementPolicy(this ArmResource armResource, string roleManagementPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleManagementPolicy(roleManagementPolicyName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleManagementPolicyAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(this ArmResource armResource, string roleManagementPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleManagementPolicyAsync(roleManagementPolicyName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleManagementPolicyAssignments()"/>
        public static RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleManagementPolicyAssignments();
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleManagementPolicyAssignment(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static Response<RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(this ArmResource armResource, string roleManagementPolicyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return GetMockableAuthorizationArmResource(armResource).GetRoleManagementPolicyAssignment(roleManagementPolicyAssignmentName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmResource.GetRoleManagementPolicyAssignmentAsync(string, CancellationToken)"/>
        [ForwardsClientCalls]
        public static async Task<Response<RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(this ArmResource armResource, string roleManagementPolicyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));

            return await GetMockableAuthorizationArmResource(armResource).GetRoleManagementPolicyAssignmentAsync(roleManagementPolicyAssignmentName, cancellationToken).ConfigureAwait(false);
        }
    }
}
