// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Update;
    using Resource.Fluent.Core.ResourceActions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for User and its parent interfaces.
    /// </summary>
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

        public string ObjectId()
        {
            return Inner.ObjectId;
        }
        public string ObjectType()
        {
            return Inner.ObjectType; 
        }
        public string UserPrincipalName()
        {
            return Inner.UserPrincipalName;
        }
        public string DisplayName()
        {
            return Inner.DisplayName;
        }
        public string SignInName()
        {
            return Inner.SignInName;
        }
        public string Mail()
        {
            return Inner.Mail;
        }
        public string MailNickname()
        {
            return Inner.MailNickname;
        }

        public UserImpl WithAccountEnabled (bool enabled)
        {
            createParameters.AccountEnabled = enabled;
            return this;
        }

        public UserImpl WithDisplayName (string displayName)
        {
            createParameters.DisplayName = displayName;
            return this;
        }

        public UserImpl WithMailNickname (string mailNickname)
        {
            createParameters.MailNickname = mailNickname;
            return this;
        }

        public UserImpl WithPassword (string password)
        {
            createParameters.PasswordProfile = new PasswordProfile
            {
                Password = password
            };
            return this;
        }

        public UserImpl WithPassword (string password, bool forceChangePasswordNextLogin)
        {
            createParameters.PasswordProfile = new PasswordProfile
            {
                Password = password,
                ForceChangePasswordNextLogin = forceChangePasswordNextLogin
            };
            return this;
        }

        public override IUser Refresh ()
        {
            var inner = client.Get(UserPrincipalName());
            SetInner(inner);
            return this;
        }

        public override Task<IUser> CreateResourceAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}