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
    public partial class ActiveDirectoryUsersImpl  :
        ReadableWrappersImpl<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser,Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUserImpl,Models.UserInner>,
        IActiveDirectoryUsers,
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsersOperations>
    {
        private GraphRbacManager manager;
                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public ActiveDirectoryUserImpl GetById(string objectId)
        {
            //$ return (ActiveDirectoryUserImpl) getByIdAsync(objectId).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().Users().GetAsync(id).Map(new Func1<UserInner, ActiveDirectoryUser>() {
            //$ @Override
            //$ public ActiveDirectoryUser call(UserInner userInner) {
            //$ if (userInner == null) {
            //$ return null;
            //$ } else {
            //$ return new ActiveDirectoryUserImpl(userInner, manager());
            //$ }
            //$ }
            //$ });

            return null;
        }

                public async Task<ServiceFuture<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser>> GetByIdAsync(string id, IServiceCallback<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(getByIdAsync(id), callback);

            return null;
        }

                internal  ActiveDirectoryUsersImpl(GraphRbacManager manager)
        {
            //$ {
            //$ this.manager = manager;
            //$ }

        }

                public ActiveDirectoryUserImpl GetByName(string upn)
        {
            //$ return (ActiveDirectoryUserImpl) getByNameAsync(upn).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().Users().GetAsync(name)
            //$ .FlatMap(new Func1<UserInner, Observable<UserInner>>() {
            //$ @Override
            //$ public Observable<UserInner> call(UserInner userInner) {
            //$ // Exact match
            //$ if (userInner != null) {
            //$ return Observable.Just(userInner);
            //$ }
            //$ // Search mail & mail nickname
            //$ if (name.Contains("@")) {
            //$ return manager().Inner().Users().ListAsync(String.Format("mail eq '%s' or mailNickName eq '%s#EXT#'", name, name.Replace("@", "_")))
            //$ .Map(new Func1<Page<UserInner>, UserInner>() {
            //$ @Override
            //$ public UserInner call(Page<UserInner> userInnerPage) {
            //$ if (userInnerPage.Items() == null || userInnerPage.Items().IsEmpty()) {
            //$ return null;
            //$ }
            //$ return userInnerPage.Items().Get(0);
            //$ }
            //$ });
            //$ }
            //$ // Search display name
            //$ else {
            //$ return manager().Inner().Users().ListAsync(String.Format("displayName eq '%s'", name))
            //$ .Map(new Func1<Page<UserInner>, UserInner>() {
            //$ @Override
            //$ public UserInner call(Page<UserInner> userInnerPage) {
            //$ if (userInnerPage.Items() == null || userInnerPage.Items().IsEmpty()) {
            //$ return null;
            //$ }
            //$ return userInnerPage.Items().Get(0);
            //$ }
            //$ });
            //$ }
            //$ }
            //$ })
            //$ .Map(new Func1<UserInner, ActiveDirectoryUser>() {
            //$ @Override
            //$ public ActiveDirectoryUser call(UserInner userInnerServiceResponse) {
            //$ if (userInnerServiceResponse == null) {
            //$ return null;
            //$ }
            //$ return new ActiveDirectoryUserImpl(userInnerServiceResponse, manager());
            //$ }
            //$ });

            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> List()
        {
            //$ return wrapList(this.manager().Inner().Users().List());

            return null;
        }

                public IUsersOperations Inner()
        {
            //$ return this.manager().Inner().Users();

            return null;
        }

                public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryUser>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(this.Inner().ListAsync());

            return null;
        }

                protected ActiveDirectoryUserImpl WrapModel(UserInner userInner)
        {
            //$ if (userInner == null) {
            //$ return null;
            //$ }
            //$ return new ActiveDirectoryUserImpl(userInner, manager());

            return null;
        }
    }
}