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
    using Rest.Azure;
    using System.Net;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUser.Definition;
    using System;

    /// <summary>
    /// The implementation of Users and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryUsersImpl  :
        ReadableWrappers<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser,Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryUserImpl,Models.UserInner>,
        IActiveDirectoryUsers,
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsersOperations>
    {
        private GraphRbacManager manager;
                public GraphRbacManager Manager()
        {
            return manager;
        }

                public ActiveDirectoryUserImpl GetById(string objectId)
        {
            return (ActiveDirectoryUserImpl) GetByIdAsync(objectId).ConfigureAwait(false).GetAwaiter().GetResult();
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(id, cancellationToken));
        }
        
                internal  ActiveDirectoryUsersImpl(GraphRbacManager manager)
        {
            this.manager = manager;
        }

                public ActiveDirectoryUserImpl GetByName(string upn)
        {
            return (ActiveDirectoryUserImpl) GetByNameAsync(upn).ConfigureAwait(false).GetAwaiter().GetResult();
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            UserInner inner = null;
            try
            {
                inner = await Inner.GetAsync(name, cancellationToken);
            }
            catch (GraphErrorException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw e;
                }
            }
            if (inner != null)
            {
                return WrapModel(inner);
            }
            if (name.Contains("@"))
            {
                var inners = await Inner.ListAsync(string.Format("mail eq '{0}' or mailNickName eq '{1}%23EXT%23'", name, name.Replace("@", "_")), cancellationToken);
                if (inners != null && inners.Any())
                {
                    return WrapModel(inners.First());
                }
            }
            else
            {
                var inners = await Inner.ListAsync(string.Format("displayName eq '{0}'", name), cancellationToken);
                if (inners != null && inners.Any())
                {
                    return WrapModel(inners.First());
                }
            }
            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser> List()
        {
            return WrapList(this.manager.Inner.Users.List());
        }

                public IUsersOperations Inner
        {
            get
            {
                return manager.Inner.Users;
            }
        }

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => throw new NotImplementedException();

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryUser>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IActiveDirectoryUser, UserInner>.LoadPage(
                async (cancellation) => await Inner.ListAsync(null, cancellation),
                Inner.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

                protected override IActiveDirectoryUser WrapModel(UserInner userInner)
        {
            if (userInner == null)
            {
                return null;
            }
            return new ActiveDirectoryUserImpl(userInner, manager);
        }

        IActiveDirectoryUser ISupportsGettingById<IActiveDirectoryUser>.GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IBlank Define(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}