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
    using System;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignment.Definition;

    /// <summary>
    /// The implementation of RoleAssignments and its parent interfaces.
    /// </summary>
    public partial class RoleAssignmentsImpl :
        CreatableResources<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment, Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignmentImpl, Models.RoleAssignmentInner>,
        IRoleAssignments,
        IHasInner<IRoleAssignmentsOperations>
    {
        private GraphRbacManager manager;
        public GraphRbacManager Manager()
        {
            return manager;
        }

        public RoleAssignmentImpl GetById(string objectId)
        {
            return (RoleAssignmentImpl)Extensions.Synchronize(() => GetByIdAsync(objectId));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await manager.RoleInner.RoleAssignments.GetByIdAsync(id, cancellationToken));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> GetByScopeAsync(string scope, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await manager.RoleInner.RoleAssignments.GetAsync(scope, name, cancellationToken));
        }

        public RoleAssignmentImpl Define(string name)
        {
            return WrapModel(name);
        }

        public async Task<IPagedCollection<IRoleAssignment>> ListByScopeAsync(string scope, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IRoleAssignment, RoleAssignmentInner>.LoadPage(
                async (cancellation) => await manager.RoleInner.RoleAssignments.ListForScopeAsync(scope, null, cancellation),
                manager.RoleInner.RoleAssignments.ListForScopeNextAsync,
                WrapModel, true, cancellationToken);
        }

        public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> ListByScope(string scope)
        {
            return WrapList(Extensions.Synchronize(() => manager.RoleInner.RoleAssignments.ListForScopeAsync(scope)));
        }

        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await manager.RoleInner.RoleAssignments.DeleteByIdAsync(id, cancellationToken);
        }

        public RoleAssignmentImpl GetByScope(string scope, string name)
        {
            return (RoleAssignmentImpl)Extensions.Synchronize(() => GetByScopeAsync(scope, name));
        }

        public IRoleAssignmentsOperations Inner
        {
            get
            {
                return manager.RoleInner.RoleAssignments;
            }
        }

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => throw new NotImplementedException();

        internal RoleAssignmentsImpl(GraphRbacManager manager)
        {
            this.manager = manager;
        }

        protected override IRoleAssignment WrapModel(RoleAssignmentInner roleAssignmentInner)
        {
            if (roleAssignmentInner == null)
            {
                return null;
            }
            return new RoleAssignmentImpl(roleAssignmentInner, manager);
        }

        protected override RoleAssignmentImpl WrapModel(string name)
        {
            return new RoleAssignmentImpl(new RoleAssignmentInner
            {
                Name = name
            }, manager);
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => manager.RoleInner.RoleAssignments.DeleteByIdAsync(id));
        }

        IRoleAssignment ISupportsGettingById<IRoleAssignment>.GetById(string id)
        {
            return WrapModel(Extensions.Synchronize(() => manager.RoleInner.RoleAssignments.GetByIdAsync(id)));
        }

        IBlank ISupportsCreating<IBlank>.Define(string name)
        {
            return WrapModel(name);
        }
    }
}