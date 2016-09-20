/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Update;
    using System.Threading;
    using System.Threading.Tasks;
    using Management.Graph.RBAC;
    using V2.Resource.Core.ResourceActions;
    using System;

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

        #region Getters

        public string ObjectId
        {
            get
            {
                return Inner.ObjectId;
            }
        }
        public string ObjectType
        {
            get
            {
                return Inner.ObjectType; 
            }
        }
        public string UserPrincipalName
        {
            get
            {
                return Inner.UserPrincipalName;
            }
        }
        public string DisplayName
        {
            get
            {
                return Inner.DisplayName;
            }
        }
        public string SignInName
        {
            get
            {
                return Inner.SignInName;
            }
        }
        public string Mail
        {
            get
            {
                return Inner.Mail;
            }
        }
        public string MailNickname
        {
            get
            {
                return Inner.MailNickname;
            }
        }

        #endregion

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

        public override async Task<IUser> Refresh ()
        {
            var inner = await client.GetAsync(UserPrincipalName);
            SetInner(inner);
            return this;
        }

        public override async Task<IUser> CreateResourceAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}