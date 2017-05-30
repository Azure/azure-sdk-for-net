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
    /// The implementation of RoleAssignments and its parent interfaces.
    /// </summary>
    public partial class RoleAssignmentsImpl  :
        CreatableResourcesImpl<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment,Microsoft.Azure.Management.Graph.RBAC.Fluent.RoleAssignmentImpl,Models.RoleAssignmentInner>,
        IRoleAssignments,
        IHasInner<Models.RoleAssignmentsInner>
    {
        private GraphRbacManager manager;
                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public RoleAssignmentImpl GetById(string objectId)
        {
            //$ return (RoleAssignmentImpl) getByIdAsync(objectId).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().RoleInner().RoleAssignments().GetByIdAsync(id).Map(new Func1<RoleAssignmentInner, RoleAssignment>() {
            //$ @Override
            //$ public RoleAssignment call(RoleAssignmentInner roleAssignmentInner) {
            //$ if (roleAssignmentInner == null) {
            //$ return null;
            //$ } else {
            //$ return new RoleAssignmentImpl(roleAssignmentInner, manager());
            //$ }
            //$ }
            //$ });

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>> GetByIdAsync(string id, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByIdAsync(id), callback);

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>> GetByScopeAsync(string scope, string name, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByScopeAsync(scope, name), callback);

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> GetByScopeAsync(string scope, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().RoleInner().RoleAssignments().GetAsync(scope, name)
            //$ .Map(new Func1<RoleAssignmentInner, RoleAssignment>() {
            //$ @Override
            //$ public RoleAssignment call(RoleAssignmentInner roleAssignmentInner) {
            //$ if (roleAssignmentInner == null) {
            //$ return null;
            //$ }
            //$ return new RoleAssignmentImpl(roleAssignmentInner, manager());
            //$ }
            //$ });

            return null;
        }

                public RoleAssignmentImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> ListByScopeAsync(string scope, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(manager().RoleInner().RoleAssignments().ListAsync());

            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> ListByScope(string scope)
        {
            //$ return wrapList(manager().RoleInner().RoleAssignments().List());

            return null;
        }

                public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().RoleInner().RoleAssignments().DeleteByIdAsync(id).ToCompletable();

            return null;
        }

                public RoleAssignmentImpl GetByScope(string scope, string name)
        {
            //$ return (RoleAssignmentImpl) getByScopeAsync(scope, name).ToBlocking().Single();

            return null;
        }

                public RoleAssignmentsInner Inner()
        {
            //$ return this.manager().RoleInner().RoleAssignments();

            return null;
        }

                internal  RoleAssignmentsImpl(GraphRbacManager manager)
        {
            //$ {
            //$ this.manager = manager;
            //$ }

        }

                protected RoleAssignmentImpl WrapModel(RoleAssignmentInner roleAssignmentInner)
        {
            //$ if (roleAssignmentInner == null) {
            //$ return null;
            //$ }
            //$ return new RoleAssignmentImpl(roleAssignmentInner, manager());

            return null;
        }

                protected RoleAssignmentImpl WrapModel(string name)
        {
            //$ return new RoleAssignmentImpl(new RoleAssignmentInner().WithName(name), manager());

            return null;
        }
    }
}