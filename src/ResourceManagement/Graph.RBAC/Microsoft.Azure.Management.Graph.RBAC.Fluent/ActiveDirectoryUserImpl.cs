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
            //$ super(innerObject);
            //$ this.manager = manager;
            //$ }

        }

                public string Mail()
        {
            //$ return inner().Mail();

            return null;
        }

                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public string SignInName()
        {
            //$ return inner().SignInName();

            return null;
        }

                public string Name()
        {
            //$ return inner().DisplayName();

            return null;
        }

                public string Id()
        {
            //$ return inner().ObjectId();

            return null;
        }

                public string UserPrincipalName()
        {
            //$ return inner().UserPrincipalName();

            return null;
        }

                public string MailNickname()
        {
            //$ return inner().MailNickname();

            return null;
        }
    }
}