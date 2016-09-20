/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Rest;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading.Tasks;
    using Management.Graph.RBAC;
    using System;

    /// <summary>
    /// The implementation of Users and its parent interfaces.
    /// </summary>
    public partial class UsersImpl :
        CreatableWrappers<IUser, UserImpl, UserInner>,
        IUsers
    {
        private IUsersOperations innerCollection;
        private GraphRbacManager manager;
        internal UsersImpl (IUsersOperations client, GraphRbacManager graphRbacManager)
        {
            this.innerCollection = client;
            this.manager = graphRbacManager;
        }

        public PagedList<IUser> List ()
        {
            var pagedList = new PagedList<UserInner>(innerCollection.List());
            return WrapList(pagedList);
        }

        public void Delete (string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public UserImpl Define (string name)
        {
            return WrapModel(name);
        }

        protected override UserImpl WrapModel (string userPrincipalName)
        {
            return new UserImpl(new UserInner
            {
                UserPrincipalName = userPrincipalName
            }, innerCollection);
        }

        protected override IUser WrapModel (UserInner userInner)
        {
            return new UserImpl(userInner, innerCollection);
        }

        public IUser GetByObjectId (string objectId)
        {
            return WrapModel(innerCollection.Get(objectId));
        }

        public IUser GetByUserPrincipalName (string upn)
        {
            return WrapModel(innerCollection.Get(upn));
        }

        public async Task<IUser> GetByUserPrincipalNameAsync (string upn, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userInner = await innerCollection.GetAsync(upn, cancellationToken);
            return WrapModel(userInner);
        }
    }
}