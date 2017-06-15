// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure AD user.
    /// </summary>
    public interface IActiveDirectoryUser  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.UserInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>
    {
        /// <summary>
        /// Gets or sets user mail.
        /// </summary>
        string Mail { get; }

        /// <summary>
        /// Gets or sets user signIn name.
        /// </summary>
        string SignInName { get; }

        /// <summary>
        /// Gets or sets user principal name.
        /// </summary>
        string UserPrincipalName { get; }

        /// <summary>
        /// Gets The mail alias for the user.
        /// </summary>
        string MailNickname { get; }
    }
}