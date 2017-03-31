// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of Users and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmdyYXBocmJhYy5pbXBsZW1lbnRhdGlvbi5Vc2Vyc0ltcGw=
    public partial class UsersImpl :
        ReadableWrappers<IUser, UserImpl, UserInner>,
        IUsers
    {
        private IUsersOperations innerCollection;
        private IGraphRbacManager manager;

        public IGraphRbacManager Manager
        {
            get
            {
                return manager;
            }
        }

        public IUsersOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

        ///GENMHASH:561BA4752C186EC8BFAF988C061767EA:B5C5E95A3298DE50C35002A7B21387E7
        internal UsersImpl (IUsersOperations client, IGraphRbacManager graphRbacManager)
        {
            this.innerCollection = client;
            this.manager = graphRbacManager;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public IEnumerable<IUser> List ()
        {
            return WrapList(innerCollection.List());
        }

        ///GENMHASH:8B08433C196DD61BBDD2BB90A9108032:A264B6A43B1DB71B6549773B10B60787
        protected override IUser WrapModel (UserInner userInner)
        {
            return new UserImpl(userInner, innerCollection);
        }

        ///GENMHASH:0DE1C4F9167E6FED0CDC9D2B979CBBBF:E43194E70421EC8C954B29021E47E934
        public IUser GetByObjectId (string objectId)
        {
            return WrapModel(innerCollection.Get(objectId));
        }

        ///GENMHASH:66CEA44DF8A8A83672D68C637C28563F:C6A1F57DB433E84F08C1ACDBA7A3128A
        public IUser GetByUserPrincipalName (string upn)
        {
            return WrapModel(innerCollection.Get(upn));
        }

        ///GENMHASH:67980B77CC1024D9E8E93AD6A0FE4FB5:5E3D7F95624AB03CBF1B12D91F295657
        public async Task<IUser> GetByUserPrincipalNameAsync (string upn, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userInner = await innerCollection.GetAsync(upn, cancellationToken);
            return WrapModel(userInner);
        }
    }
}
