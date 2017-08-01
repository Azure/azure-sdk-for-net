// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using Rest;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class RoleAssignmentImpl :
        Creatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment, Models.RoleAssignmentInner, Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignmentImpl, IRoleAssignment>,
        IRoleAssignment,
        IDefinition
    {
        private GraphRbacManager manager;
        private string objectId;
        private string userName;
        private string servicePrincipalName;
        private string roleDefinitionId;
        private string roleName;

        string IHasId.Id => Inner.Id;

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => manager;

        public RoleAssignmentImpl ForUser(IActiveDirectoryUser user)
        {
            this.objectId = user.Id;
            return this;
        }

        public RoleAssignmentImpl ForUser(string name)
        {
            this.userName = name;
            return this;
        }

        public RoleAssignmentImpl WithBuiltInRole(BuiltInRole role)
        {
            this.roleName = role.Value;
            return this;
        }

        public RoleAssignmentImpl WithResourceScope(IResource resource)
        {
            return WithScope(resource.Id);
        }

        internal RoleAssignmentImpl(RoleAssignmentInner innerObject, GraphRbacManager manager)
            : base(innerObject.Name, innerObject)
        {
            this.manager = manager;
        }

        public GraphRbacManager Manager()
        {
            return manager;
        }

        public RoleAssignmentImpl ForGroup(IActiveDirectoryGroup activeDirectoryGroup)
        {
            this.objectId = activeDirectoryGroup.Id;
            return this;
        }

        public bool IsInCreateMode()
        {
            return Inner.Id == null;
        }

        public RoleAssignmentImpl ForServicePrincipal(IServicePrincipal servicePrincipal)
        {
            this.objectId = servicePrincipal.Id;
            return this;
        }

        public RoleAssignmentImpl ForServicePrincipal(string servicePrincipalName)
        {
            this.servicePrincipalName = servicePrincipalName;
            return this;
        }

        public string PrincipalId()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return Inner.Properties.PrincipalId;
        }

        public RoleAssignmentImpl ForObjectId(string objectId)
        {
            this.objectId = objectId;
            return this;
        }

        protected override async Task<Models.RoleAssignmentInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.RoleInner.RoleAssignments.GetByIdAsync(Id(), cancellationToken);
        }

        public string RoleDefinitionId()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return Inner.Properties.RoleDefinitionId;
        }

        public RoleAssignmentImpl WithRoleDefinition(string roleDefinitionId)
        {
            this.roleDefinitionId = roleDefinitionId;
            return this;
        }

        public string Scope()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return Inner.Properties.Scope;
        }

        public RoleAssignmentImpl WithScope(string scope)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new RoleAssignmentPropertiesWithScope();
            }
            Inner.Properties.Scope = scope;
            return this;
        }

        public RoleAssignmentImpl WithResourceGroupScope(IResourceGroup resourceGroup)
        {
            return WithScope(resourceGroup.Id);
        }

        public string Id()
        {
            return Inner.Id;
        }

        public RoleAssignmentImpl WithSubscriptionScope(string subscriptionId)
        {
            return WithScope("subscriptions/" + subscriptionId);
        }

        public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (objectId == null)
            {
                if (userName != null)
                {
                    objectId = (await manager.Users.GetByNameAsync(userName, cancellationToken)).Id;
                }
                else if (servicePrincipalName != null)
                {
                    objectId = (await manager.ServicePrincipals.GetByNameAsync(servicePrincipalName, cancellationToken)).Id;
                }
                else
                {
                    throw new ValidationException("Please pass a non-null value for either object id, user, group, or service principal");
                }
            }

            if (roleDefinitionId == null)
            {
                if (roleName != null)
                {
                    roleDefinitionId = (await manager.RoleDefinitions.GetByScopeAndRoleNameAsync(Scope(), roleName, cancellationToken)).Id;
                }
                else
                {
                    throw new ValidationException("Please pass a non-null value for either role name or role definition ID");
                }
            }

            var propertiesInner = new RoleAssignmentPropertiesInner
            {
                PrincipalId = objectId,
                RoleDefinitionId = roleDefinitionId
            };
            var inner = await manager.RoleInner.RoleAssignments.CreateAsync(Scope(), Name, propertiesInner, cancellationToken);
            SetInner(inner);
            return this;
        }
    }
}