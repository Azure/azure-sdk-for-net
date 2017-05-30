// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// The implementation of RoleDefinitions and its parent interfaces.
    /// </summary>
    public partial class RoleDefinitionsImpl  :
        ReadableWrappersImpl<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition,Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleDefinitionImpl,Models.RoleDefinitionInner>,
        IRoleDefinitions,
        IHasInner<Models.RoleDefinitionsInner>
    {
        private GraphRbacManager manager;
                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public RoleDefinitionImpl GetById(string objectId)
        {
            //$ return (RoleDefinitionImpl) getByIdAsync(objectId).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().RoleInner().RoleDefinitions().GetByIdAsync(id).Map(new Func1<RoleDefinitionInner, RoleDefinition>() {
            //$ @Override
            //$ public RoleDefinition call(RoleDefinitionInner roleDefinitionInner) {
            //$ if (roleDefinitionInner == null) {
            //$ return null;
            //$ } else {
            //$ return new RoleDefinitionImpl(roleDefinitionInner, manager());
            //$ }
            //$ }
            //$ });

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition>> GetByIdAsync(string id, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByIdAsync(id), callback);

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition>> GetByScopeAsync(string scope, string name, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByScopeAsync(scope, name), callback);

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByScopeAsync(string scope, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().RoleInner().RoleDefinitions().GetAsync(scope, name)
            //$ .Map(new Func1<RoleDefinitionInner, RoleDefinition>() {
            //$ @Override
            //$ public RoleDefinition call(RoleDefinitionInner roleDefinitionInner) {
            //$ if (roleDefinitionInner == null) {
            //$ return null;
            //$ }
            //$ return new RoleDefinitionImpl(roleDefinitionInner, manager());
            //$ }
            //$ });

            return null;
        }

                public RoleDefinitionImpl GetByScopeAndRoleName(string scope, string roleName)
        {
            //$ return (RoleDefinitionImpl) getByScopeAndRoleNameAsync(scope, roleName).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> ListByScopeAsync(string scope, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(manager().RoleInner().RoleDefinitions().ListAsync(scope));

            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> ListByScope(string scope)
        {
            //$ return wrapList(manager().RoleInner().RoleDefinitions().List(scope));

            return null;
        }

                internal  RoleDefinitionsImpl(GraphRbacManager manager)
        {
            //$ {
            //$ this.manager = manager;
            //$ }

        }

                public RoleDefinitionImpl GetByScope(string scope, string name)
        {
            //$ return (RoleDefinitionImpl) getByScopeAsync(scope, name).ToBlocking().Single();

            return null;
        }

                public RoleDefinitionsInner Inner()
        {
            //$ return this.manager().RoleInner().RoleDefinitions();

            return null;
        }

                protected RoleDefinitionImpl WrapModel(RoleDefinitionInner roleDefinitionInner)
        {
            //$ if (roleDefinitionInner == null) {
            //$ return null;
            //$ }
            //$ return new RoleDefinitionImpl(roleDefinitionInner, manager());

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition>> GetByScopeAndRoleNameAsync(string scope, string roleName, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByScopeAndRoleNameAsync(scope, roleName), callback);

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByScopeAndRoleNameAsync(string scope, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().RoleInner().RoleDefinitions().ListAsync(scope, String.Format("roleName eq '%s'", roleName))
            //$ .Map(new Func1<Page<RoleDefinitionInner>, RoleDefinition>() {
            //$ @Override
            //$ public RoleDefinition call(Page<RoleDefinitionInner> roleDefinitionInnerPage) {
            //$ if (roleDefinitionInnerPage == null || roleDefinitionInnerPage.Items() == null || roleDefinitionInnerPage.Items().IsEmpty()) {
            //$ return null;
            //$ }
            //$ return new RoleDefinitionImpl(roleDefinitionInnerPage.Items().Get(0), manager());
            //$ }
            //$ });

            return null;
        }
    }
}