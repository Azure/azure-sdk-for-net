// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class ActiveDirectoryUserImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets or sets user principal name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.UserPrincipalName
        {
            get
            {
                return this.UserPrincipalName();
            }
        }

        /// <summary>
        /// Gets The mail alias for the user.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.MailNickname
        {
            get
            {
                return this.MailNickname();
            }
        }

        /// <summary>
        /// Gets or sets user mail.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.Mail
        {
            get
            {
                return this.Mail();
            }
        }

        /// <summary>
        /// Gets or sets user signIn name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryUser.SignInName
        {
            get
            {
                return this.SignInName();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager;
            }
        }
    }
}