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
    /// The implementation of Users and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryGroupsImpl  :
        ReadableWrappersImpl<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup,Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroupImpl,Models.ADGroupInner>,
        IActiveDirectoryGroups
    {
        private GraphRbacManager manager;
                internal  ActiveDirectoryGroupsImpl(GraphRbacManager manager)
        {
            //$ this.manager = manager;
            //$ }

        }

                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public ActiveDirectoryGroupImpl GetById(string objectId)
        {
            //$ return (ActiveDirectoryGroupImpl) getByIdAsync(objectId).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager.Inner().Groups().GetAsync(id)
            //$ .Map(new Func1<ADGroupInner, ActiveDirectoryGroup>() {
            //$ @Override
            //$ public ActiveDirectoryGroup call(ADGroupInner groupInner) {
            //$ if (groupInner == null) {
            //$ return null;
            //$ } else {
            //$ return new ActiveDirectoryGroupImpl(groupInner, manager());
            //$ }
            //$ }
            //$ });

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup>> GetByIdAsync(string id, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByIdAsync(id), callback);

            return null;
        }

                public IActiveDirectoryGroup GetByName(string name)
        {
            //$ return getByNameAsync(name).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().Groups().ListAsync(String.Format("displayName eq '%s'", name))
            //$ .Map(new Func1<Page<ADGroupInner>, ActiveDirectoryGroup>() {
            //$ @Override
            //$ public ActiveDirectoryGroup call(Page<ADGroupInner> adGroupInnerPage) {
            //$ if (adGroupInnerPage.Items() == null || adGroupInnerPage.Items().IsEmpty()) {
            //$ return null;
            //$ } else {
            //$ return new ActiveDirectoryGroupImpl(adGroupInnerPage.Items().Get(0), manager());
            //$ }
            //$ }
            //$ });

            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup> List()
        {
            //$ return wrapList(this.manager.Inner().Groups().List());

            return null;
        }

                public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryGroup>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(manager().Inner().Groups().ListAsync());

            return null;
        }

                public IGroupsOperations Inner()
        {
            //$ return manager().Inner().Groups();

            return null;
        }

                protected ActiveDirectoryGroupImpl WrapModel(ADGroupInner groupInner)
        {
            //$ if (groupInner == null) {
            //$ return null;
            //$ }
            //$ return new ActiveDirectoryGroupImpl(groupInner, manager());

            return null;
        }
    }
}