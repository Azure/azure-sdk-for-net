// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class RoleAssignmentImpl  :
        Creatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment,Models.RoleAssignmentInner,Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignmentImpl,IRoleAssignment>,
        IRoleAssignment,
        IDefinition
    {
        private GraphRbacManager manager;
        private string objectId;
        private string userName;
        private string servicePrincipalName;
        private string roleDefinitionId;
        private string roleName;
                public RoleAssignmentImpl ForUser(IActiveDirectoryUser user)
        {
            //$ this.objectId = user.Id();
            //$ return this;

            return this;
        }

                public RoleAssignmentImpl ForUser(string name)
        {
            //$ this.userName = name;
            //$ return this;

            return this;
        }

                public RoleAssignmentImpl WithBuiltInRole(BuiltInRole role)
        {
            //$ this.roleName = role.ToString();
            //$ return this;

            return this;
        }

                public RoleAssignmentImpl WithResourceScope(IResource resource)
        {
            //$ return withScope(resource.Id());

            return this;
        }

                internal  RoleAssignmentImpl(RoleAssignmentInner innerObject, GraphRbacManager manager)
                    : base(innerObject.Name, innerObject)
        {
            //$ super(innerObject.Name(), innerObject);
            //$ this.manager = manager;
            //$ }

        }

                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public RoleAssignmentImpl ForGroup(IActiveDirectoryGroup activeDirectoryGroup)
        {
            //$ this.objectId = activeDirectoryGroup.Id();
            //$ return this;

            return this;
        }

                public bool IsInCreateMode()
        {
            //$ return inner().Id() == null;

            return false;
        }

                public RoleAssignmentImpl ForServicePrincipal(IServicePrincipal servicePrincipal)
        {
            //$ this.objectId = servicePrincipal.Id();
            //$ return this;

            return this;
        }

                public RoleAssignmentImpl ForServicePrincipal(string servicePrincipalName)
        {
            //$ this.servicePrincipalName = servicePrincipalName;
            //$ return this;

            return this;
        }

                public string PrincipalId()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return inner().Properties().PrincipalId();

            return null;
        }

                public RoleAssignmentImpl ForObjectId(string objectId)
        {
            //$ this.objectId = objectId;
            //$ return this;

            return this;
        }

                protected override async Task<Models.RoleAssignmentInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager.RoleInner().RoleAssignments().GetAsync(scope(), name());

            return null;
        }

                public string RoleDefinitionId()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return inner().Properties().RoleDefinitionId();

            return null;
        }

                public RoleAssignmentImpl WithRoleDefinition(string roleDefinitionId)
        {
            //$ this.roleDefinitionId = roleDefinitionId;
            //$ return this;

            return this;
        }

                public string Scope()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return inner().Properties().Scope();

            return null;
        }

                public RoleAssignmentImpl WithScope(string scope)
        {
            //$ if (this.Inner().Properties() == null) {
            //$ this.Inner().WithProperties(new RoleAssignmentPropertiesWithScope());
            //$ }
            //$ this.Inner().Properties().WithScope(scope);
            //$ return this;

            return this;
        }

                public RoleAssignmentImpl WithResourceGroupScope(IResourceGroup resourceGroup)
        {
            //$ return withScope(resourceGroup.Id());

            return this;
        }

                public string Id()
        {
            //$ return inner().Id();

            return null;
        }

                public RoleAssignmentImpl WithSubscriptionScope(string subscriptionId)
        {
            //$ return withScope("subscriptions/" + subscriptionId);

            return this;
        }

                public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<String> objectIdObservable;
            //$ if (objectId != null) {
            //$ objectIdObservable = Observable.Just(objectId);
            //$ } else if (userName != null) {
            //$ objectIdObservable = manager.Users().GetByNameAsync(userName)
            //$ .Map(new Func1<ActiveDirectoryUser, String>() {
            //$ @Override
            //$ public String call(ActiveDirectoryUser user) {
            //$ return user.Id();
            //$ }
            //$ });
            //$ } else if (servicePrincipalName != null) {
            //$ objectIdObservable = manager.ServicePrincipals().GetByNameAsync(servicePrincipalName)
            //$ .Map(new Func1<ServicePrincipal, String>() {
            //$ @Override
            //$ public String call(ServicePrincipal sp) {
            //$ return sp.Id();
            //$ }
            //$ });
            //$ } else {
            //$ throw new IllegalArgumentException("Please pass a non-null value for either object Id, user, group, or service principal");
            //$ }
            //$ 
            //$ Observable<String> roleDefinitionIdObservable;
            //$ if (roleDefinitionId != null) {
            //$ roleDefinitionIdObservable = Observable.Just(roleDefinitionId);
            //$ } else if (roleName != null) {
            //$ roleDefinitionIdObservable = manager().RoleDefinitions().GetByScopeAndRoleNameAsync(scope(), roleName)
            //$ .Map(new Func1<RoleDefinition, String>() {
            //$ @Override
            //$ public String call(RoleDefinition roleDefinition) {
            //$ return roleDefinition.Id();
            //$ }
            //$ });
            //$ } else {
            //$ throw new IllegalArgumentException("Please pass a non-null value for either role name or role definition ID");
            //$ }
            //$ 
            //$ return Observable.Zip(objectIdObservable, roleDefinitionIdObservable, new Func2<String, String, RoleAssignmentPropertiesInner>() {
            //$ @Override
            //$ public RoleAssignmentPropertiesInner call(String objectId, String roleDefinitionId) {
            //$ return new RoleAssignmentPropertiesInner()
            //$ .WithPrincipalId(objectId).WithRoleDefinitionId(roleDefinitionId);
            //$ }
            //$ }).FlatMap(new Func1<RoleAssignmentPropertiesInner, Observable<RoleAssignmentInner>>() {
            //$ @Override
            //$ public Observable<RoleAssignmentInner> call(RoleAssignmentPropertiesInner roleAssignmentPropertiesInner) {
            //$ return manager().RoleInner().RoleAssignments()
            //$ .CreateAsync(scope(), name(), roleAssignmentPropertiesInner);
            //$ }
            //$ }).Map(innerToFluentMap(this));

            return null;
        }
    }
}