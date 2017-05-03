// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure AD user.
    /// </summary>
    public interface IUser  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.Models.UserInner>
    {
        /// <summary>
        /// Gets or sets user principal name.
        /// </summary>
        string UserPrincipalName { get; }

        /// <summary>
        /// Gets or sets user mail.
        /// </summary>
        string Mail { get; }

        /// <summary>
        /// Gets The mail alias for the user.
        /// </summary>
        string MailNickname { get; }

        /// <summary>
        /// Gets or sets user signIn name.
        /// </summary>
        string SignInName { get; }

        /// <summary>
        /// Gets or sets object Id.
        /// </summary>
        string ObjectId { get; }

        /// <summary>
        /// Gets or sets user display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets or sets object type.
        /// </summary>
        string ObjectType { get; }
    }
}