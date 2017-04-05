// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Update;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for User and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmdyYXBocmJhYy5pbXBsZW1lbnRhdGlvbi5Vc2VySW1wbA==
    public partial class UserImpl :
        CreatableUpdatable<IUser, UserInner, UserImpl, IUser, IUpdate>,
        IUser,
        IDefinition,
        IUpdate
    {
        private IUsersOperations client;
        private UserCreateParametersInner createParameters;

        internal UserImpl (UserInner innerModel, IUsersOperations client)
            : base(innerModel.UserPrincipalName, innerModel)
        {
            this.client = client;
            this.createParameters = new UserCreateParametersInner()
            {
                UserPrincipalName = innerModel.UserPrincipalName
            };
        }

        ///GENMHASH:17540EB75C744FB87D329C55BE359E09:CC8D1D4F5D89E231669C5963BF9F8E9C
        public string ObjectId()
        {
            return Inner.ObjectId;
        }

        ///GENMHASH:29024ACA1EA67366DE27F7A1B972E458:75852A31ACA71709FD61BA0195203BFF
        public string ObjectType()
        {
            return Inner.ObjectType; 
        }

        ///GENMHASH:EFC2DDE75F20FD4EAFECA334A50B3D22:5BCCB61C94FA98FEF1E7D90DCFADBDAC
        public string UserPrincipalName()
        {
            return Inner.UserPrincipalName;
        }

        ///GENMHASH:19FB5490B29F08AC39628CD5F893E975:54FC41D8034FD612C7047E2055BC6E48
        public string DisplayName()
        {
            return Inner.DisplayName;
        }

        ///GENMHASH:A150E806D025822AB5DF5438B386C9F2:B9161EACDBFE5F3F7DD00C6D41D6BAD9
        public string SignInName()
        {
            return Inner.SignInName;
        }

        ///GENMHASH:16EBDFC8CC602D680E0E32486328D684:D10E9C733A0AA33D44CE2D08891F4EBE
        public string Mail()
        {
            return Inner.Mail;
        }

        ///GENMHASH:EE18A3AEA61BB82949B949BE68947AEF:63DB386E96A2AED639FF5547DC1C798C
        public string MailNickname()
        {
            return Inner.MailNickname;
        }

        ///GENMHASH:8B8E171AB3970DFD7516F84B8C19861C:4549C714DB7AE421B3ED125CD30CFEF9
        public UserImpl WithAccountEnabled (bool enabled)
        {
            createParameters.AccountEnabled = enabled;
            return this;
        }

        ///GENMHASH:EDAD7B033C93B5FEE1419E438619ABF3:A38066E817331F8A02982D526BB9FCD4
        public UserImpl WithDisplayName (string displayName)
        {
            createParameters.DisplayName = displayName;
            return this;
        }

        ///GENMHASH:75B32599B63ECD9641B6137878074EDC:6FBD2E638868C5040F1A6890F0E21C85
        public UserImpl WithMailNickname (string mailNickname)
        {
            createParameters.MailNickname = mailNickname;
            return this;
        }

        ///GENMHASH:60802F24CA383B85E354D13337FC6F3B:7D053BF8F6F40DCECFA694D1267667E2
        public UserImpl WithPassword (string password)
        {
            createParameters.PasswordProfile = new PasswordProfile
            {
                Password = password
            };
            return this;
        }

        ///GENMHASH:7F35F6C48498D28343D85BFC4C2F3D05:16256DB0E4447967C89B6A1BC27BBEDB
        public UserImpl WithPassword (string password, bool forceChangePasswordNextLogin)
        {
            createParameters.PasswordProfile = new PasswordProfile
            {
                Password = password,
                ForceChangePasswordNextLogin = forceChangePasswordNextLogin
            };
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:5074689AB449399B3C11F611FD3EFF94
        protected override async Task<UserInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await client.GetAsync(UserPrincipalName(), cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:E9A4DA014B21051979442ACE026C7D1F
        public override Task<IUser> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
