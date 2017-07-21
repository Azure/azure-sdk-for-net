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

    /// <summary>
    /// The implementation of Users and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryGroupsImpl :
        ReadableWrappers<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup, Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroupImpl, Models.ADGroupInner>,
        IActiveDirectoryGroups
    {
        private GraphRbacManager manager;
        internal ActiveDirectoryGroupsImpl(GraphRbacManager manager)
        {
            this.manager = manager;
        }

        public GraphRbacManager Manager()
        {
            return manager;
        }

        public ActiveDirectoryGroupImpl GetById(string objectId)
        {
            return (ActiveDirectoryGroupImpl) Extensions.Synchronize(() => GetByIdAsync(objectId));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(id, cancellationToken));
        }

        public IActiveDirectoryGroup GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<ADGroupInner> inners = await Inner.ListAsync(string.Format("displayName eq '{0}'", name), cancellationToken);
            if (inners == null || !inners.Any())
            {
                return null;
            }
            return WrapModel(inners.First());
        }

        public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync()));
        }

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryGroup>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IActiveDirectoryGroup, ADGroupInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(null, cancellation),
                Inner.ListNextAsync,
                (inner) => WrapModel(inner), loadAllPages, cancellationToken);
        }

        public IGroupsOperations Inner
        {
            get
            {
                return manager.Inner.Groups;
            }
        }

        protected override IActiveDirectoryGroup WrapModel(ADGroupInner groupInner)
        {
            if (groupInner == null)
            {
                return null;
            }
            return new ActiveDirectoryGroupImpl(groupInner, manager);
        }
    }
}