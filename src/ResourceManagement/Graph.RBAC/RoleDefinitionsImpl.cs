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
    using System.Linq;
    using System;

    /// <summary>
    /// The implementation of RoleDefinitions and its parent interfaces.
    /// </summary>
    public partial class RoleDefinitionsImpl :
        ReadableWrappers<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition, Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleDefinitionImpl, Models.RoleDefinitionInner>,
        IRoleDefinitions,
        IHasInner<IRoleDefinitionsOperations>
    {
        private GraphRbacManager manager;
        public GraphRbacManager Manager()
        {
            return manager;
        }

        public RoleDefinitionImpl GetById(string objectId)
        {
            return (RoleDefinitionImpl)Extensions.Synchronize(() => GetByIdAsync(objectId));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await manager.RoleInner.RoleDefinitions.GetByIdAsync(id, cancellationToken));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByScopeAsync(string scope, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await manager.RoleInner.RoleDefinitions.GetAsync(scope, name, cancellationToken));
        }

        public RoleDefinitionImpl GetByScopeAndRoleName(string scope, string roleName)
        {
            return (RoleDefinitionImpl)Extensions.Synchronize(() => GetByScopeAndRoleNameAsync(scope, roleName));
        }

        public async Task<IPagedCollection<IRoleDefinition>> ListByScopeAsync(string scope, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IRoleDefinition, RoleDefinitionInner>.LoadPage(
                async (cancelltation) => await manager.RoleInner.RoleDefinitions.ListAsync(scope, null, cancelltation),
                manager.RoleInner.RoleDefinitions.ListNextAsync,
                WrapModel, true, cancellationToken);
        }

        public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> ListByScope(string scope)
        {
            return WrapList(Extensions.Synchronize(() => manager.RoleInner.RoleDefinitions.ListAsync(scope)));
        }

        internal RoleDefinitionsImpl(GraphRbacManager manager)
        {
            this.manager = manager;
        }

        public RoleDefinitionImpl GetByScope(string scope, string name)
        {
            return (RoleDefinitionImpl)Extensions.Synchronize(() => GetByScopeAsync(scope, name));
        }

        public IRoleDefinitionsOperations Inner
        {
            get
            {
                return manager.RoleInner.RoleDefinitions;
            }
        }

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => manager;

        protected override IRoleDefinition WrapModel(RoleDefinitionInner roleDefinitionInner)
        {
            if (roleDefinitionInner == null)
            {
                return null;
            }
            return new RoleDefinitionImpl(roleDefinitionInner, manager);
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleDefinition> GetByScopeAndRoleNameAsync(string scope, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inners = await Inner.ListAsync(scope, string.Format("roleName eq '{0}'", roleName), cancellationToken);
            if (inners == null || !inners.Any())
            {
                return null;
            }
            return WrapModel(inners.First());
        }

        IRoleDefinition ISupportsGettingById<IRoleDefinition>.GetById(string id)
        {
            return WrapModel(Extensions.Synchronize(() => manager.RoleInner.RoleDefinitions.GetByIdAsync(id)));
        }
    }
}