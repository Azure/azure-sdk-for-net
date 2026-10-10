// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// The TypeSpec management generator intentionally does not generate generic ArmResource extensions;
// this custom type preserves the shipped GA mocking API.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Authorization.Mocking
{
    /// <summary> A class to add extension methods to <see cref="ArmResource"/>. </summary>
    public partial class MockableAuthorizationArmResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableAuthorizationArmResource"/> class for mocking. </summary>
        protected MockableAuthorizationArmResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableAuthorizationArmResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableAuthorizationArmResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetAuthorizationRoleDefinitions(ResourceIdentifier)"/>
        public virtual AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions()
        {
            return GetCachedClient(client => new AuthorizationRoleDefinitionCollection(client, Id));
        }

        /// <summary> Gets the role definition identified by <paramref name="roleDefinitionId"/> at this resource scope. </summary>
        /// <param name="roleDefinitionId"> The role definition resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The role definition response. </returns>
        [ForwardsClientCalls]
        public virtual Response<AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return GetAuthorizationRoleDefinitions().Get(roleDefinitionId.ToString(), cancellationToken);
        }

        /// <summary> Gets the role definition identified by <paramref name="roleDefinitionId"/> at this resource scope. </summary>
        /// <param name="roleDefinitionId"> The role definition resource identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The role definition response. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(ResourceIdentifier roleDefinitionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return await GetAuthorizationRoleDefinitions().GetAsync(roleDefinitionId.ToString(), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetDenyAssignments(ResourceIdentifier)"/>
        public virtual DenyAssignmentCollection GetDenyAssignments()
        {
            return GetCachedClient(client => new DenyAssignmentCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetDenyAssignment(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<DenyAssignmentResource> GetDenyAssignment(string denyAssignmentId, CancellationToken cancellationToken = default)
        {
            return GetDenyAssignments().Get(denyAssignmentId, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetDenyAssignmentAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<DenyAssignmentResource>> GetDenyAssignmentAsync(string denyAssignmentId, CancellationToken cancellationToken = default)
        {
            return await GetDenyAssignments().GetAsync(denyAssignmentId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignments(ResourceIdentifier)"/>
        public virtual RoleAssignmentCollection GetRoleAssignments()
        {
            return GetCachedClient(client => new RoleAssignmentCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignment(ResourceIdentifier, string, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignmentResource> GetRoleAssignment(string roleAssignmentName, string tenantId = null, CancellationToken cancellationToken = default)
        {
            return GetRoleAssignments().Get(roleAssignmentName, tenantId, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentAsync(ResourceIdentifier, string, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignmentResource>> GetRoleAssignmentAsync(string roleAssignmentName, string tenantId = null, CancellationToken cancellationToken = default)
        {
            return await GetRoleAssignments().GetAsync(roleAssignmentName, tenantId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentSchedules(ResourceIdentifier)"/>
        public virtual RoleAssignmentScheduleCollection GetRoleAssignmentSchedules()
        {
            return GetCachedClient(client => new RoleAssignmentScheduleCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentSchedule(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(string roleAssignmentScheduleName, CancellationToken cancellationToken = default)
        {
            return GetRoleAssignmentSchedules().Get(roleAssignmentScheduleName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(string roleAssignmentScheduleName, CancellationToken cancellationToken = default)
        {
            return await GetRoleAssignmentSchedules().GetAsync(roleAssignmentScheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleInstances(ResourceIdentifier)"/>
        public virtual RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances()
        {
            return GetCachedClient(client => new RoleAssignmentScheduleInstanceCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleInstance(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(string roleAssignmentScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            return GetRoleAssignmentScheduleInstances().Get(roleAssignmentScheduleInstanceName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleInstanceAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(string roleAssignmentScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            return await GetRoleAssignmentScheduleInstances().GetAsync(roleAssignmentScheduleInstanceName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleRequests(ResourceIdentifier)"/>
        public virtual RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests()
        {
            return GetCachedClient(client => new RoleAssignmentScheduleRequestCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleRequest(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(string roleAssignmentScheduleRequestName, CancellationToken cancellationToken = default)
        {
            return GetRoleAssignmentScheduleRequests().Get(roleAssignmentScheduleRequestName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleAssignmentScheduleRequestAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(string roleAssignmentScheduleRequestName, CancellationToken cancellationToken = default)
        {
            return await GetRoleAssignmentScheduleRequests().GetAsync(roleAssignmentScheduleRequestName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilitySchedules(ResourceIdentifier)"/>
        public virtual RoleEligibilityScheduleCollection GetRoleEligibilitySchedules()
        {
            return GetCachedClient(client => new RoleEligibilityScheduleCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilitySchedule(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(string roleEligibilityScheduleName, CancellationToken cancellationToken = default)
        {
            return GetRoleEligibilitySchedules().Get(roleEligibilityScheduleName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(string roleEligibilityScheduleName, CancellationToken cancellationToken = default)
        {
            return await GetRoleEligibilitySchedules().GetAsync(roleEligibilityScheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleInstances(ResourceIdentifier)"/>
        public virtual RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances()
        {
            return GetCachedClient(client => new RoleEligibilityScheduleInstanceCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleInstance(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(string roleEligibilityScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            return GetRoleEligibilityScheduleInstances().Get(roleEligibilityScheduleInstanceName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleInstanceAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(string roleEligibilityScheduleInstanceName, CancellationToken cancellationToken = default)
        {
            return await GetRoleEligibilityScheduleInstances().GetAsync(roleEligibilityScheduleInstanceName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleRequests(ResourceIdentifier)"/>
        public virtual RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests()
        {
            return GetCachedClient(client => new RoleEligibilityScheduleRequestCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleRequest(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(string roleEligibilityScheduleRequestName, CancellationToken cancellationToken = default)
        {
            return GetRoleEligibilityScheduleRequests().Get(roleEligibilityScheduleRequestName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleEligibilityScheduleRequestAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(string roleEligibilityScheduleRequestName, CancellationToken cancellationToken = default)
        {
            return await GetRoleEligibilityScheduleRequests().GetAsync(roleEligibilityScheduleRequestName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleManagementPolicies(ResourceIdentifier)"/>
        public virtual RoleManagementPolicyCollection GetRoleManagementPolicies()
        {
            return GetCachedClient(client => new RoleManagementPolicyCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleManagementPolicy(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleManagementPolicyResource> GetRoleManagementPolicy(string roleManagementPolicyName, CancellationToken cancellationToken = default)
        {
            return GetRoleManagementPolicies().Get(roleManagementPolicyName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleManagementPolicyAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(string roleManagementPolicyName, CancellationToken cancellationToken = default)
        {
            return await GetRoleManagementPolicies().GetAsync(roleManagementPolicyName, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleManagementPolicyAssignments(ResourceIdentifier)"/>
        public virtual RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments()
        {
            return GetCachedClient(client => new RoleManagementPolicyAssignmentCollection(client, Id));
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleManagementPolicyAssignment(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual Response<RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(string roleManagementPolicyAssignmentName, CancellationToken cancellationToken = default)
        {
            return GetRoleManagementPolicyAssignments().Get(roleManagementPolicyAssignmentName, cancellationToken);
        }

        /// <inheritdoc cref="MockableAuthorizationArmClient.GetRoleManagementPolicyAssignmentAsync(ResourceIdentifier, string, CancellationToken)"/>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(string roleManagementPolicyAssignmentName, CancellationToken cancellationToken = default)
        {
            return await GetRoleManagementPolicyAssignments().GetAsync(roleManagementPolicyAssignmentName, cancellationToken).ConfigureAwait(false);
        }
    }
}
