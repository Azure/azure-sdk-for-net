// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for User and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryUserImpl  :
        Wrapper<Models.UserInner>,
        IActiveDirectoryUser
    {
        private GraphRbacManager manager;
                internal  ActiveDirectoryUserImpl(UserInner innerObject, GraphRbacManager manager)
                : base (innerObject)
        {
            this.manager = manager;
        }

                public string Mail()
        {
            return Inner.Mail;
        }

                public GraphRbacManager Manager()
        {
            return manager;
        }

                public string SignInName()
        {
            return Inner.SignInName;
        }

                public string Name()
        {
            return Inner.DisplayName;
        }

                public string Id()
        {
            return Inner.ObjectId;
        }

                public string UserPrincipalName()
        {
            return Inner.UserPrincipalName;
        }

                public string MailNickname()
        {
            return Inner.MailNickname;
        }
    }
}